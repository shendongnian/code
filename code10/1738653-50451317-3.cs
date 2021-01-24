    public void SaveFile(DataTable dt, string fileName)
    {
        var list = new List<IEnumerable<string>>();
        list.Add(dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName));
        list.AddRange(dt.Rows.Cast<DataRow>().Select(x => x.ItemArray.Cast<string>()));
        var lines = list.Select(x => string.Join(";", x));
        System.IO.File.WriteAllLines(fileName, lines);
    }
