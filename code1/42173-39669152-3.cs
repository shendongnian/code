    using (var memoryStream = new MemoryStream())
    {
        using (var textwriter = new StreamWriter(memoryStream))
        {
            using (var csv = new CsvWriter(textwriter))
            {
                //..write some stuff to the stream using the CsvWriter
            }
        }
        
        return memoryStream.ToArray();
    }
