    public static int GetIntConfiguration(string keyName)
    {
        string value = ConfigurationManager.AppSettings[keyName] ?? "0";
        int theValue = 0;
        if (int.TryParse(value, out theValue))
        {
           return theValue;
        }
        return -1;
    }
