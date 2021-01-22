    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    
    ds1.Tables.Add(new DataTable());
    ds2.Tables.Add(new DataTable());
    
    ds1.Tables[0].Columns.Add("tblkey");
    ds1.Tables[0].Columns.Add("empkey");
    ds1.Tables[0].Columns.Add("empname");
    
    ds2.Tables[0].Columns.Add("empkey");
    ds2.Tables[0].Columns.Add("empname");
    
    ds1.Tables[0].Rows.Add("T101", "E10", "Natraj");
    ds1.Tables[0].Rows.Add("T102", "E11", "Siva");
    ds1.Tables[0].Rows.Add("T103", "E14", "ganesh");
    
    ds2.Tables[0].Rows.Add("E10", "karthi");
    ds2.Tables[0].Rows.Add("E11", "thriu");
    ds2.Tables[0].Rows.Add("E13", "maran");
    
    // primary keys must be set in order for the merge to work
    ds1.Tables[0].PrimaryKey = new DataColumn[] { ds1.Tables[0].Columns["empkey"] };
    ds2.Tables[0].PrimaryKey = new DataColumn[] { ds2.Tables[0].Columns["empkey"] };
    
    // this is the critical line
    ds1.Merge(ds2, true, MissingSchemaAction.Add);
