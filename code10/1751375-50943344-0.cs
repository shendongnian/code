    DataTable dt = new DataTable();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    dt.Columns.Add("Column3");
    foreach (var item in query)
    {
        var row = dt.NewRow();
        row["Column1"] = item.Column1;
        row["Column2"] = item.Column2;
        row["Column3"] = item.Column3;
        dt.Rows.Add(row);
    }
    return dt;
