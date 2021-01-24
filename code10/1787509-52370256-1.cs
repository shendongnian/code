        DataTable dt = new DataTable();
        dt.Columns.Add("A");
        dt.Columns.Add("B");
        dt.Rows.Add("1", "5");
        dt.Rows.Add("6", "10");
        dt.Rows.Add("11", "15");
        var output = dt.Rows.Cast<DataRow>().SelectMany(x => new[] { x[0], x[1] }).ToList();
