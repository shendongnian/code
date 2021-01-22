    public static string GetExternalIP()
    {
         using (var wc = new System.Net.WebClient())
             return wc.DownloadString("http://whatismyip.org");
    }
