    async Task CopyFileAsync(FileInfo infile, FileInfo outFile)
    {
         using(var textReader = inFile.OpenText())
         {
            using (var textWriter = outFile.CreateText())
            {
                // Read a line. Wait until line read
                var line = await textReader.ReadLineAsync();
                while (line != null)
                {
                    // Write the line. Don't wait until line written
                    var writeTask = textWrite.WriteLineAsync(line);
                    // While the line is being written, I'm free to read the next line. 
                    line = textReader.ReadLine();
                    // await until the previous line has been written:
                    await writeTask;
                }
            }
        }
    }
