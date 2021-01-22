    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Collections.Generic;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(AreEqual(
                    new DirectoryInfo("C:\\Scratch"),
                    new DirectoryInfo("C:\\Scratch\\")));
    
                Console.WriteLine(AreEqual(
                    new DirectoryInfo("C:\\Windows\\Microsoft.NET\\Framework"),
                    new DirectoryInfo("C:\\Windows\\Microsoft.NET\\Framework\\v3.5\\1033\\..\\..")));
    
                Console.WriteLine(AreEqual(
                    new DirectoryInfo("C:\\Scratch\\"),
                    new DirectoryInfo("C:\\Scratch\\4760\\..\\..")));
    
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
    
            private static bool AreEqual(DirectoryInfo dir1, DirectoryInfo dir2)
            {
                DirectoryInfo parent1 = dir1;
                DirectoryInfo parent2 = dir2;
    
                /* Build a list of parents */
                List<string> folder1Parents = new List<string>();
                List<string> folder2Parents = new List<string>();
    
                while (parent1 != null)
                {
                    folder1Parents.Add(parent1.Name);
                    parent1 = parent1.Parent;
                }
    
                while (parent2 != null)
                {
                    folder2Parents.Add(parent2.Name);
                    parent2 = parent2.Parent;
                }
    
                /* Now compare the lists */
    
                if (folder1Parents.Count != folder2Parents.Count)
                {
                    // Cannot be the same - different number of parents
                    return false;
                }
    
                bool equal = true;
    
                for (int i = 0; i < folder1Parents.Count && i < folder2Parents.Count; i++)
                {
                    equal &= folder1Parents[i] == folder2Parents[i];
                }
    
                return equal;
            }
        }
    }
