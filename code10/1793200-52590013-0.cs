    var good = new List<Test>();
    var bad = new List<string>();
    using (var stream = new MemoryStream())
    using (var writer = new StreamWriter(stream))
    using (var reader = new StreamReader(stream))
    using (var csv = new CsvReader(reader))
    {
        writer.WriteLine("FirstName,LastName");
        writer.WriteLine("\"Jon\"hn\"\",\"Doe\"");
        writer.WriteLine("\"JaneDoe\"");
        writer.WriteLine("\"Jane\",\"Doe\"");
        writer.Flush();
        stream.Position = 0;
        var isRecordBad = false;
        csv.Configuration.BadDataFound = context =>
        {
            isRecordBad = true;
            bad.Add(context.RawRecord);
        };
        csv.Configuration.MissingFieldFound = (headerNames, index, context) =>
        {
            isRecordBad = true;
            bad.Add(context.RawRecord);
        };
        while (csv.Read())
        {
            var record = csv.GetRecord<Test>();
            if (!isRecordBad)
            {
                good.Add(record);
            }
            isRecordBad = false;
        }
    }
    good.Dump();
    bad.Dump();
