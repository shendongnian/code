    /// <summary>
    /// Implements a Function to get all available IFilters currently registered in this system
    /// </summary>    
    public string GetFilterList()
    {
        //Our resulting string. We give back a ';' seperated list of extensions.
        string result = @"";
        string persistentHandlerClass;
        RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"Software\Classes");
        if (rk == null)
            return null;
        using (rk)
        {
            foreach(string subKeyName in rk.GetSubKeyNames())
            {
                if (subKeyName[0] == '.') //possible Extension
                {
                    RegistryKey sk = Registry.LocalMachine.OpenSubKey(@"Software\Classes\" + subKeyName + @"\PersistentHandler");
                    if (sk == null)
                        continue;
                    
                    using (sk)
                    {
                        persistentHandlerClass = (string)sk.GetValue(null);
                    }
                    if (persistentHandlerClass != null)
                    {
                        string filterPersistClass = ReadStrFromHKLM(@"Software\Classes\CLSID\" + persistentHandlerClass +
                            @"\PersistentAddinsRegistered\{89BCB740-6119-101A-BCB7-00DD010655AF}");
                        string dllName = ReadStrFromHKLM(@"Software\Classes\CLSID\" + filterPersistClass + @"\InprocServer32");
                        // skip query.dll results, cause it's not an IFilter itself
                        if (dllName != null && filterPersistClass != null && (dllName.IndexOf("query.dll") < 0))
                        {
                            //result = result + subKeyName + @"[" + dllName + @"] - persistentHandlerClassAddin: " + persistentHandlerClass + "\r\n";  //[C:\Windows\system32\query.dll]
                            //result = result + subKeyName + @"[" + dllName + @"];";  //[C:\Windows\system32\query.dll]
                            result = result + subKeyName.ToLower() + @";";
                        }
                    }
                }
            }
            return result;
        }
    }
