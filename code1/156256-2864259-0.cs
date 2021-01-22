    var con = new EntityConnectionStringBuilder()
      {
        Metadata = @"res://*/Db.TracModel.csdl|res://*/Db.TracModel.ssdl|res://*/Db.TracModel.msl",
        Provider = @"System.Data.SQLite",
        ProviderConnectionString = new SqlConnectionStringBuilder()
          {
            DataSource = db,
          }.ConnectionString,
      };
    
    connection = con.ConnectionString;
