    using (TextReader dataCsvFileReader = File.OpenText(inputFile))
    {
        using (CsvReader dataCsvReader = new CsvReader(dataCsvFileReader))
        {
            while (dataCsvReader.Read())
            {
                var dataRecord = Enumerable.ToList(dataCsvReader.GetRecord<dynamic>());
            }
        }
    }
    
