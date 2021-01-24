    if (!File.Exists(path))
    {
        throw new FileNotFoundException(path + " not found");
    }
    using (TextReader reader = new StreamReader(path))
    using (var csvReader = new CsvReader(reader))
    {
        csvReader.Configuration.Delimiter = ";";
        var dataRecords = csvReader.GetRecords<dynamic>();
        foreach (var record in dataRecords)
        {
            IDictionary<string, object> propertyValues = record;
            Console.WriteLine($"-> {propertyValues.Count} Columns {{{string.Join(", ", propertyValues.Keys)}}}");
            foreach (var property in propertyValues.Keys)
            {
                Console.WriteLine(String.Format("{0} : {1}", property, propertyValues[property]));
            }
        }
    }
