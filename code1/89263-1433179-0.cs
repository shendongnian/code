    /// <summary>
    /// Gets all System data source names for the local machine.
    /// </summary>
    public System.Collections.SortedList GetSystemDataSourceNames()
    {
        System.Collections.SortedList dsnList = new System.Collections.SortedList();
    
        // get system dsn's
        Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software");
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
                            dsnList.Add(sName, DataSourceType.System);
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
