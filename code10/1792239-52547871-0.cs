        var setting = ConfigurationManager.ConnectionStrings["ConStr"];
        if( setting == null ) {
              throw new Exception ("Unable to retrieve connection string")
        }
        string ConStr = setting.ConnectionString;
        if( string.IsNullOrEmpty(ConStr) ) {
              throw new Exception ("Connection string is empty");
        }
