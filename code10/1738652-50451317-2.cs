    DataTable LoadFile(string fileName)
    {
        var dt = new DataTable();
        var lines = System.IO.File.ReadAllLines(fileName);
        if (lines.Count() == 0)
            return dt;
        lines.First().Split(';').ToList().ForEach(x =>
        {
            dt.Columns.Add(new DataColumn(x));
        });
        lines.Skip(1).ToList().ForEach(x =>
        {
            dt.Rows.Add(x.Split(';'));
        });
        return dt;
    }
