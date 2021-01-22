    Database db = myServer.Databases["MyDB"];
    
    if (! db.Tables.Contains("NewTable"))
    {
    
        Table tbl = new Table(db, "NewTable");
    
        Column col1 = new Column(tbl, "Column1", DataType.Varchar(10));
        col1.Nullable = true;
        tbl.Columns.Add(col1);
    
        tbl.Create();
    
    }
