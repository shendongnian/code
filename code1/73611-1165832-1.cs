    using(RegistryKey sqlServerKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
    {
        foreach (string subKeyName in sqlServerKey.GetSubKeyNames())
        {
            if(subKeyName.StartsWith("MSSQL."))
            {
                using(RegistryKey instanceKey = sqlServerKey.OpenSubKey(subKeyName))
                {
                    string instanceName = instanceKey.GetValue("").ToString();
    
                    if (instanceName == "MSSQLSERVER")//say
                    {
                        string path = instanceKey.OpenSubKey(@"Setup").GetValue("SQLBinRoot").ToString();
                        path = Path.Combine(path, "sqlserver.exe");
                        return path;
                    }
                }
            }
        }
    }
