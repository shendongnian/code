    var t2 = new DataTable();
    t2.Columns.AddRange(table.Columns.Cast<DataColumn>().ToArray());
    foreach(var r in distinct)
    {
        t2.Rows.Add(r);
    }
