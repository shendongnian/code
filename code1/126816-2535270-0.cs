    try
     {
        System.Data.OleDb.OleDbConnection MyConnection ;
        System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
        string sql = null;
        MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\csharp.net-informations.xls';Extended Properties=Excel 8.0;");
        MyConnection.Open();
        myCommand.Connection = MyConnection;
    
        myCommand.CommandText = "Insert into [Sheet1$] (id,name) values('@p1', '@p2')";
        myCommand.Parameters.Add("@p1", OleDbType.VarChar, 100);
        myCommand.Parameters.Add("@p2", OleDbType.VarChar, 100);
    
        // define query to entity data model
        var model = from i in myEntity.Inquiries select i;
    
        foreach(var m in model)
        {    
           cmd.Parameters["@p1"].Value = m.RequestID;
           cmd.Parameters["@p2"].Value = m.CustomerName;
           // .. Add other parameters here
          cmd.ExecuteNonQuery();
        }
      } 
