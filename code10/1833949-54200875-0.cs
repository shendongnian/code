    public bool CanSetRegKeyValue(string path, string valueName, RegistryKey registry = null)
    {
        bool result = true;
    
        try
        {
            RegistryKey registryKey = null;
    
            if (registry == null)
            {
                registryKey = Registry.LocalMachine;
            }
    
            using (RegistryKey key = registryKey.OpenSubKey(path, true))
            {
                result = key != null;
            }
        }
        catch (NullReferenceException)
        {
            result = false;
        }
        catch (SecurityException)
        {
            result = false;
        }
    
        return result;
    }
