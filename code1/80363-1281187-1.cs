    public static double PingTimeAverage(string host, int echoNum)
    {
        long totalTime = 0;
        int timeout = 120;
        Ping pingSender = new Ping ();
        for (int i = 0; i < echoNum; i++)
        { 
            PingReply reply = pingSender.Send (host, timeout);
            if (reply.Status == IPStatus.Success)
            {
                totalTime += reply.RoundtripTime;
            }
        }
        return totalTime / echoNum;
    }
