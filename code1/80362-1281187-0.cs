    public static double PingTimeAverage(string host, int echoNum)
    {
        long totalTime = 0;
        Ping pingSender = new Ping ();
    
        // Create a buffer of 32 bytes of data to be transmitted.
        string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        byte[] buffer = Encoding.ASCII.GetBytes (data);
        int timeout = 120;
    
        for (int i = 0; i < echoNum; i++)
        { 
            PingReply reply = pingSender.Send (host, timeout, buffer, null);
            if (reply.Status == IPStatus.Success)
            {
                totalTime += reply.RoundtripTime;
            }
        }
        return totalTime / echoNum;
    }
