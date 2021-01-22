    using (TextWriter writer = new StreamWriter(filePath)
    {
        var csvWriter = new CsvWriter(writer);
        csvWriter.Configuration.Delimiter = "\t";
        csvWriter.Configuration.Encoding = Encoding.UTF8;
        csvWriter.WriteRecords(exportRecords); 
    }
