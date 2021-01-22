    System.Net.NetworkInformation;
    public static bool CheckInternetConnection()
    {
       try
       {
           Ping myPing = new Ping();
           String host = "google.com";
           byte[] buffer = new byte[32];
           int timeout = 1000;
           PingOptions pingOptions = new PingOptions();
           PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
        }
        catch (Exception)
        {
           return false;
        }
    }
