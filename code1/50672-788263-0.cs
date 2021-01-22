    DataTable dt = new DataTable();
    DataColumn column = new DataColumn("Col1");
    column.AllowDBNull = false;
    dt.Columns.Add(column);
    DataRow dr = dt.NewRow();
    dr["Col1"] = null;
    dt.Rows.Add(dr);
