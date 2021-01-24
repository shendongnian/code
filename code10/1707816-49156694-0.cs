    var tempFileName = Path.GetTempFileName();
    try
    {
        using (var streamReader = new StreamReader(file))
        using (var streamWriter = new StreamWriter(tempFileName))
        {
            string line;
            bool isFirstLine = true;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (!isFirstLine)
                        streamWrite.WriteLine();
                    streamWriter.Write(line);
                    isFirstLine = false;
                }
            }
        }
        File.Delete(file);
        File.Move(tempFileName, file);
    }
    finally
    {
        File.Delete(tempFileName);
    }
