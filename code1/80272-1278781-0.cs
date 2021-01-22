    public static string XMLCheck
    {
        get
        {
            var section =(Hashtable)ConfigurationManager.GetSection("PowershellSnapIns");
            return (string)section["SnapIn1"];
        }
    }
