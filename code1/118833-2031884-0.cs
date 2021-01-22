    public static bool HasConnection()
    {
        try
        {
            System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
            return true;
        }
        catch
        {
            return false;
        }
    }
