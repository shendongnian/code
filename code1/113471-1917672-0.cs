    using System;
    using System.IO;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            // This creates a lookup from filename to the set of 
            // directories containing that file
            var textFiles = 
                Directory.GetFiles("I:\\pax", "*.txt", SearchOption.AllDirectories)
                         .ToLookup(file => Path.GetFileName(file),
                                   file => Path.GetDirectoryName(file));
            
            string[] fileNames = File.ReadAllLines(@"c:\file.txt");
            // Remove the quotes for your real code :)
            string targetDirectory = "C:\\" + "textBox1.Text" + @"\\N\\O\\";
            foreach (string fileName in fileNames)
            {
                string tmp = fileName + ".txt";
                foreach (string directory in textFiles[tmp])
                {
                    string source = Path.Combine(directory, tmp);
                    string target = Path.Combine(targetDirectory, tmp);
                    File.Copy(source, target);                                       
                }
            }
        }
    }
