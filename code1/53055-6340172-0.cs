    public static void ClearFirefoxCookies()
    {
        int procCount = Process.GetProcessesByName("firefox").Length;
        if (procCount > 0)
            throw new ApplicationException(string.Format("There are {0} instances of Firefox still running", procCount));
    
        try
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + GetFirefoxCookiesFileName()))
            { 
                conn.Open();
                SQLiteCommand command = conn.CreateCommand();
                command.CommandText = "delete from moz_cookies";
                int count = command.ExecuteNonQuery();
            }
        }
        catch (SQLiteException ex)
        {
            if (!(ex.ErrorCode == SQLiteErrorCode.Busy || ex.ErrorCode == SQLiteErrorCode.Locked))
                throw new ApplicationException("The Firefox cookies.sqlite file is locked");
        }
    }
    private static string GetFirefoxCookiesFileName()
    {
        string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), @"Mozilla\Firefox\Profiles");
        if (!System.IO.Directory.Exists(path))
            throw new ApplicationException("Firefox profiles folder not found");
    
        string[] fileNames = System.IO.Directory.GetFiles(path, "cookies.sqlite", System.IO.SearchOption.AllDirectories);
        if (fileNames.Length != 1 || !System.IO.File.Exists(fileNames[0]))
            throw new ApplicationException("Firefox cookies.sqlite file not found");
        return fileNames[0];
    }
