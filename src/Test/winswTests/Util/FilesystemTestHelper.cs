﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace winswTests.Util
{
    class FilesystemTestHelper
    {
        /// <summary>
        /// Creates a temporary directory for testing.
        /// </summary>
        /// <returns>tmp Dir</returns>
        public static string CreateTmpDirectory(String testName = null)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "winswTests_" + (testName ?? "") + Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            Console.Out.WriteLine("Created the temporary directory: {0}", tempDirectory);
            return tempDirectory;
        }

        /// <summary>
        /// Parses output of the "set" command from the file
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Dictionary of the strings.</returns>
        public static Dictionary<string, string> parseSetOutput(string filePath)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            var lines = File.ReadAllLines(filePath);
            foreach(var line in lines) {
                var parsed = line.Split("=".ToCharArray(), 2);
                if (parsed.Length == 2)
                {
                    res.Add(parsed[0], parsed[1]);
                }
                else
                {
                    Assert.Fail("Wrong line in the parsed Set output file: " + line);
                }
            }
            return res;
        }
    }
}
