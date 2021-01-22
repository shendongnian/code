    public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new System.Net.WebClient())
            {
                client.DownloadString(new Uri("http://www.google.com"));
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
