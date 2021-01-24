    [System.Runtime.InteropServices.DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
    
    public static bool IsConnected()
    {
         return InternetGetConnectedState(out int description, 0);         
    }
