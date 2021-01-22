    using System;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
            int line_to_edit = 2;
            string sourceFile = "source.txt";
            string destinationFile = "target.txt";
            string tempFile = "target2.txt";
    
            // Read the appropriate line from the file.
            string lineToWrite = null;
            using (StreamReader reader = new StreamReader(sourceFile))
            {
                for (int i = 1; i <= line_to_edit; ++i)
                    lineToWrite = reader.ReadLine();
            }
    
            if (lineToWrite == null)
                throw new InvalidDataException("Line does not exist in " + sourceFile);
    
            // Read from the target file and write to a new file.
            int line_number = 1;
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
            // TODO: Delete the old file and replace it with the new file here.
        }
    }
