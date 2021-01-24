    DataTable dttypes = new DataTable();
    dttypes.Columns.Add("rsno", typeof(String));
    dttypes.Columns.Add("type", typeof(int));
    dttypes.Columns.Add("cnt", typeof(int));
    foreach (var t in typeinfo)
    {
      //you need to add row like this i.e. by calling NewRow() method
      //this can be issue in you code 
        row = dttypes.NewRow();
        row["rsno"] = t.rsno;
        row["type"] = t.type;
        row["cnt"] = t.cnt;
        dttypes.Rows.Add(row);
    }
