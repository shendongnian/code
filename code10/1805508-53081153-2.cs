    void Start()
    {
        int period = 21; // trial period
        string keyName = "/Datefile.txt";
        long ticks = DateTime.Today.Ticks;
        rootKey = Registry.CurrentUser;
        regKey = rootKey.OpenSubKey(keyName);
        if (regKey == null) // first time app has been used
        {
            regKey = rootKey.CreateSubKey(keyName);
            expiry = DateTime.Today.AddDays(period).Ticks;
            regKey.SetValue("expiry", expiry.ToString(), RegistryValueKind.String);
            regKey.Close();
        }
        else
        {
            var s = regKey.GetValue("expiry").ToString();
            expiry = long.Parse(s);
            regKey.Close();
            long today = DateTime.Today.Ticks;
            if (today > expiry)
            {
                //Debug.Log("Application has expired.");
                //Application.Quit();
            }
        }
    }
