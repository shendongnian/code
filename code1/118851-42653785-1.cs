    public static bool Isconnected = false;
    public static bool CheckForInternetConnection()
    {
        try
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else if (reply.Status == IPStatus.TimedOut)
            {
                return Isconnected;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
    public static void CheckConnection()
    {
        if (CheckForInternetConnection())
        {
            Isconnected = true;
        }
        else
        {
            Isconnected = false;
        }
    }
