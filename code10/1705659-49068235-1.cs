    using(var stream = new MemoryStream())
    using(var reader = new StreamReader(stream))
    using(var writer = new StreamWriter(stream))
    using(var csvWriter = new CsvHelper.CsvWriter(writer))
    {
        //csvWriter.Configuration.HasHeaderRecord = false;
        foreach( var s in test)
        {
            csvWriter.WriteField(s);
        }
        
        writer.Flush();
        stream.Position = 0;     
        reader.ReadToEnd(); //dump it where you want           
    }
