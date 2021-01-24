    public ActionResult Get(string id)
    {
        WebClient WC = new WebClient();
        string FileName = "file.dll";
        string FTPURL = "ftp://address/";
        string Username = "username";
        string Password = "password";
        string CompletePath = FTPURL + FileName;
        try
        {
            WC.Credentials = new NetworkCredential(Username, Password);
            return File(WC.DownloadData(new Uri(CompletePath)), "text/plain");
        }
        catch (Exception e)
        {
            return File(new byte[0], "text/plain");
        }
    }
