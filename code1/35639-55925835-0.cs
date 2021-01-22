            RegistryKey reg = (Registry.LocalMachine).OpenSubKey("Software");
            reg = reg.OpenSubKey("ODBC");
            reg = reg.OpenSubKey("ODBC.INI");
            reg = reg.OpenSubKey("ODBC Data Sources");
            string instance = "";
            foreach (string item in reg.GetValueNames())
            {
                instance = item;
            }
