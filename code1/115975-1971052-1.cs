    using System;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            int line_to_edit = 2; // Warning: 1-based indexing!
            string sourceFile = "source.txt";
            string destinationFile = "target.txt";
    
            // Read the appropriate line from the file.
            string lineToWrite = null;
            using (StreamReader reader = new StreamReader(sourceFile))
            {
                for (int i = 1; i <= line_to_edit; ++i)
                    lineToWrite = reader.ReadLine();
            }
    
            if (lineToWrite == null)
                throw new InvalidDataException("Line does not exist in " + sourceFile);
    
            // Read the old file.
            string[] lines = File.ReadAllLines(destinationFile);
            // Write the new file over the old file.
            using (StreamWriter writer = new StreamWriter(destinationFile))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }
    }
