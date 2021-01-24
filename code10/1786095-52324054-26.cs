    using (var stream = File.OpenRead(filePath))
    using (var textReader = new StreamReader(stream))
    {
        foreach (var obj in JsonExtensions.FromNewlineDelimitedJson<object, RecordedDataHeader, PressureMap>(textReader))
        {
            if (obj is RecordedDataHeader)
            {
                var header = (RecordedDataHeader)obj;
                // Process the header
                Console.WriteLine(JsonConvert.SerializeObject(header));
            }
            else
            {
                var row = (PressureMap)obj;
                // Process the row.
                Console.WriteLine(JsonConvert.SerializeObject(row));
            }
        }
    }
