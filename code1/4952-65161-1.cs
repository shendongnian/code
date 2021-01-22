    // a_RootKey is Microsoft.Win32.RegistryKey 
    // DSN is a class not provided in this code sample - you can see what properties are needed from the usage below.
    
    List<DSN> DsnList = new List<DSN>();
    Microsoft.Win32.RegistryKey SearchKey = a_RootKey.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources");
    
    if (SearchKey != null)
    {
        foreach (string DsnName in SearchKey.GetValueNames() )
        {    
            if ( (string)SearchKey.GetValue(DsnName) == "SQL Server" )
            {
                Microsoft.Win32.RegistryKey anotherkey  = a_RootKey.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\" + DSNName);
                DSN dsn = new DSN();
                dsn.Name = DSNName;
                dsn.Server = (string)anotherkey.GetValue("Server");
                dsn.Database = (string)anotherkey.GetValue("Database");
                dsn.Driver = (string)anotherkey.GetValue("Driver");
                DsnList.Add(dsn);
            }
        }
    }
    return DsnList;
