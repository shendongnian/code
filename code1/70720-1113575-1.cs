    DataTable dt = new DataTable("MyTable");
    dt.Columns.Add("ID", typeof(int));
    dt.Columns.Add("Column1", typeof(string));
    dt.Columns.Add("Column2", typeof(DateTime));
    
    foreach (var o in _myObjectList) {
        DataRow dr = dt.NewRow();
        dr["ID"] = o.ID;
        dr["Column1"] = o.Column1;
        dr["Column2"] = o.Column2;
        dt.Rows.Add(dr);
    }
