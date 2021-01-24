    using System;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        internal static class Program
        {
            private static void Main(string[] args)
            {
                try
                {
                    // Get the filename from the applications arguments
                    string filename = args[0];
    
                    // Read in all lines in the file.
                    var linesInFile = File.ReadLines(filename);
    
                    // Filter out the lines we don't need.
                    var linesToKeep = linesInFile.Where(line => !line.Contains("CM") && !line.Contains("Filling")).ToArray();
    
                    // Overwrite the file.
                    File.WriteAllLines(filename, linesToKeep);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
