    string conString = ConfigurationManager
                          .ConnectionStrings["EditRegionConnectionString"]
                          .ConnectionString;
    
    Table<cont> table1 = new DataContext(conString).GetTable<cont>();  
