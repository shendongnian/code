    public IEnumerable<Row> Execute(IEnumerable<Row> rows)
    {
        foreach(var line in File.EnumerateLines())
        {
            var row = new Row();
            row["key"] = int.Parse(line.Substring(1));
            yield return row;
        }
    }
    
    public IEnumerable<Row> Execute(IEnumerable<Row> rows)
    {
        foreach(var row in rows)
        {
            var value = (int)row["key"];
            row["key"] = value + 2;
            yield return row;
        }
    }
    
    public IEnumerable<Row> Execute(IEnumerable<Row> rows)
    {
        using (var file = new Streamwriter(filename))
        {
            foreach(var row in rows)
            {
                file.WriteLine(row["key"]);
                yield return row;
            }
        }
    }
