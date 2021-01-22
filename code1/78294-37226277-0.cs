    void InternetConnection(string str)
    {
        ProcessStartInfo internet = new ProcessStartInfo()
        {
            FileName = "cmd.exe",
            Arguments = "/C ipconfig /" + str,
            WindowStyle = ProcessWindowStyle.Hidden
        };  
        Process.Start(internet);
    }
