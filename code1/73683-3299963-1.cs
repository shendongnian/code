    //even cooler as an extension method
    static IEnumerable<string> ReadAsLines(string filename)
    {
        using (var reader = new StreamReader(filename))
            while (!reader.EndOfStream)
                yield return reader.ReadLine();
    }
    
    static void Main()
    {
        var filename = "tabfile.txt";
        var reader = ReadAsLines(filename);
        var data = new DataTable();
        //this assume the first record is filled with the column names
        var headers = reader.First().Split('\t');
        foreach (var header in headers)
            data.Columns.Add(header);
        var records = reader.Skip(1);
        foreach (var record in records)
            data.Rows.Add(record.Split('\t'));
    }
