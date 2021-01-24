    public static Func<string> UserIpGetter;
    public void WriteToLog(string message)
    {
    	string userIp = UserIpGetter();
    	WriteToDB(message, userIp);
    }
