     foreach (System.Configuration.ConnectionStringSettings css in System.Configuration.ConfigurationManager.ConnectionStrings)
     {
       string connectionString = css.ConnectionString;  
       // encryption part
       // rewriting the connectionString in the app.config or however you want ot be done 
     }
