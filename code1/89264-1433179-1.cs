    /// <summary>
    /// Gets all User data source names for the local machine.
    /// </summary>
    public System.Collections.SortedList GetUserDataSourceNames()
    {
        System.Collections.SortedList dsnList = new System.Collections.SortedList();
    
        // get user dsn's
        Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.CurrentUser).OpenSubKey("Software");
        if (reg != null)
        {
            reg = reg.OpenSubKey("ODBC");
            if (reg != null)
            {
                reg = reg.OpenSubKey("ODBC.INI");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC Data Sources");
                    if (reg != null)
                    {
                        // Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                        foreach (string sName in reg.GetValueNames())
                        {
                            dsnList.Add(sName, DataSourceType.User);
                        }
                    }
                    try
                    {
                        reg.Close();
                    }
                    catch { /* ignore this exception if we couldn't close */ }
                }
            }
        }
    
        return dsnList;
    }
