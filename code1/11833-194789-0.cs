    private static int ERROR_SUCCESS = 0;
    public static bool IsInternetConnected() {
        long dwConnectionFlags = 0;
        if (!InternetGetConnectedState(dwConnectionFlags, 0))
            return false;
        if(InternetAttemptConnect(0) != ERROR_SUCCESS)
            return false;
        return true;
    }
     [DllImport("wininet.dll", SetLastError=true)]
     public static extern int InternetAttemptConnect(uint res);
     [DllImport("wininet.dll", SetLastError=true)]
     public static extern bool InternetGetConnectedState(long flags,long reserved); 
     
