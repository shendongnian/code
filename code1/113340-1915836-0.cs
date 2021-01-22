    private static void ReplaceTextInFile(string originalFile, string outputFile, string searchTerm, string replaceTerm)
    {
        string tempLineValue;
        using (FileStream inputStream = File.OpenRead(originalFile) )
        {
            using (StreamReader inputReader = new StreamReader(inputStream))
            {
                using (StreamWriter outputWriter = File.AppendText(outputFile))
                {
                    while(null != (tempLineValue = inputReader.ReadLine()))
                    {
                        outputWriter.WriteLine(tempLineValue.Replace(searchTerm,replaceTerm));
                    }
                }
            }
        }
    }
