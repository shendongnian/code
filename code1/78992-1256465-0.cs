    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
    scsb.DataSource = "LOCALHOST";
    scsb.InitialCatalog = ...;
    scsb.IntegratedSecurity = false;
    scsb.UserID = ...;
    scsb.Password = ...;
    
    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
    scsb.DataSource = "LOCALHOST";
    scsb.InitialCatalog = ...;
    scsb.IntegratedSecurity = true;
    
