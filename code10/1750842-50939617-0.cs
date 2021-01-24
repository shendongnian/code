    public static string MDF_Directory
    {
        get
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.GetFullPath(Path.Combine(directoryPath, "..//..//..//TestDB"));
        }
    }
    public string astootConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; " +
            "AttachDbFilename="+ MDF_Directory + "\\Astoot.mdf;" +
            " Integrated Security=True; Connect Timeout=30;";
