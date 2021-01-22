    using System;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            int line_number = 1;
            int line_to_edit = 2;
            string sourceFile = "source.txt";
            string destinationFile = "target.txt";
            string tempFile = "target2.txt";
    
            string lineToWrite = null;
            using (StreamReader reader = new StreamReader(sourceFile))
            {
                for (int i = 0; i < line_to_edit; ++i)
                    lineToWrite = reader.ReadLine();
            }
    
            if (lineToWrite == null)
                throw new InvalidDataException("Line does not exist in " + sourceFile);
    
            using (StreamReader reader = new StreamReader(destinationFile))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line_number == line_to_edit)
                    {
                        writer.WriteLine(lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                    line_number++;
                }
            }
        }
    }
