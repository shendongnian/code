    DataTable lDT2 = someMethod(); //populated with data from SomeMethod()
    DataTable lDT3 = new DataTable();
    lDT3.Columns.Add("Name", typeof(string));
    lDT3.Columns.Add("Name2", typeof(string));
    foreach (DataColumn col in lDT2.Columns) {
        lDT3.Columns.Add(col.ColumnName, col.DataType);
    }
                       
    foreach (DataRow dr in lDT2.Rows) {
       DataRow lDT3dr = lDT3.NewRow();
       for (int i = 0; i < lDT2.Columns.Count; i++) {
           if (i == 0) { lDT3dr[i] = "some info"; }
           if (i == 1) { lDT3dr[i] = "more info"; }
           lDT3dr[i+2] = dr[i];
        }
        lDT3.Rows.Add(lDT3dr);
    }
