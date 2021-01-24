    private IEnumerable<CsvItem_WithARealName> GetCsvItems(string filePath)
    {
        using (var fileReader = File.OpenText(filePath))
        using (var csvReader = new CsvHelper.CsvReader(fileReader))
        {
            csvReader.Configuration.CultureInfo = CultureInfo.InvariantCulture;
            csvReader.Configuration.HasHeaderRecord = false;
            csvReader.Configuration.RegisterClassMap<CsvItemMapper>();
            while (csvReader.Read())
            {
                var record = csvReader.GetRecord<CsvItem_WithARealName>();
                yield return record;
            }
        }
    }
