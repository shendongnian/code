    static public bool RegistryKeyValueDataIdentical(string keyName, string valueName, string valueData)
    {
        bool returnvalue = false;
        try
        {
            if (RegistryPathExists(keyName,valueName))
            {
                if (valueData == Microsoft.Win32.Registry.GetValue(keyName, valueName, null).ToString())
                returnvalue = true;
                else returnvalue = false;
            }
            else returnvalue = false;
        }
        catch
        {
            returnvalue = false;
        }
        return returnvalue;
    }
    static public bool RegistryPathExists(string keyName, string valueName)
    {
        try
        {
            return (Microsoft.Win32.Registry.GetValue(keyName, valueName, null) != null);
        }
        catch
        {
            return false;
        }
    }
