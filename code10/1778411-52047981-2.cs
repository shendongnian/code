    using (var sr = new StreamReader(csvFile.FullName))
    {
        using (var csvReader = new CsvReader(sr))
        {
            csvReader.Configuration.RegisterClassMap<MyCsvMap>();
            return csvReader.GetRecords<Foo>().ToList();
        }
    }
