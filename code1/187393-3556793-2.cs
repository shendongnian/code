    static void ConcatenateFiles(string outputFile, params string[] inputFiles)
    {
        using (Stream output = File.OpenWrite(outputFile))
        {
            foreach (string inputFile in inputFiles)
            {
                using (Stream input = File.OpenRead(inputFile))
                {
                    input.CopyTo(output);
                }
            }
        }
    }
