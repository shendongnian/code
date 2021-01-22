    using System;
    using System.IO;
    
    class Program
    {
        public static void Main(string[] args)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(currentDir);
            FileInfo file = new FileInfo(args[0]);
            
            string fullDirectory = directory.FullName;
            string fullFile = file.FullName;
            
            if (!fullFile.StartsWith(fullDirectory))
            {
                Console.WriteLine("Unable to make relative path");
            }
            else
            {
                // The +1 is to avoid the directory separator
                Console.WriteLine("Relative path: {0}",
                                  fullFile.Substring(fullDirectory.Length+1));
            }
        }
    }
