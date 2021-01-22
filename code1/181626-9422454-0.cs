    using (var client = new SvnClient())
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            client.Write(new SvnUriTarget(urlToFile), memoryStream);
            memoryStream.Position = 0;
            var streamReader = new StreamReader(memoryStream);
            int lineCount = 0;
            while (streamReader.ReadLine() != null)
            {
                lineCount++;
            }
        }
    }
