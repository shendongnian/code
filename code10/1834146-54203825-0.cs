    string sourceDirectory = @"C:\foo";
        try
        {
            var allFiles
              = Directory.EnumerateFiles(sourceDirectory, "*", SearchOption.AllDirectories);
            foreach (string currentFile in allFiles)
            {
                string fileName = currentFile.Substring(sourceDirectory.Length + 1);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
