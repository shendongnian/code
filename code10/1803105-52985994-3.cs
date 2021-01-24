    List<IDictionary<string, object>> dataRecords  ;
    using (TextReader reader = new StreamReader(path))
    using (var csvReader = new CsvReader(reader))
    {
        csvReader.Configuration.Delimiter = ";";
        dataRecords = csvReader.GetRecords<dynamic>()
                               .Select(x =>  (IDictionary<string, object>)x) 
                               .ToList();
    }
    foreach (var record in dataRecords)
    {
        Console.WriteLine($"-> {record.Count} Columns {{{string.Join(", ", record.Keys)}}}");
        foreach (var property in record.Keys)
        {
            Console.WriteLine(String.Format("\t{0} : {1}", property, record[property]));
        }
    }
