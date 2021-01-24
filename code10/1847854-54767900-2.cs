    void CopyFile(FileInfo infile, FileInfo outFile)
    {
         using(var textReader = inFile.OpenText())
         {
            using (var textWriter = outFile.CreateText())
            {
                // Read a line. Wait until line read
                var line = textReader.ReadLine();
                while (line != null)
                {
                    // Write the line. Wait until line written
                    textWrite.WriteLine(line);
                    // Read the next line. Wait until line read
                    line = textReader.ReadLine();
                }
            }
        }
    }
