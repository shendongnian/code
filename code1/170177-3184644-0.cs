    DataSet DS = new DataSet();
    DataTable DT = new DataTable("Table1");
    DT.Columns.Add(new DataColumn("column1", typeof(string)));
    DS.Tables.Add(DT);
    
    adapter.Fill(ds , "Table1");
