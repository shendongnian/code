    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out ConnectedStateFlag lpdwFlags, int dwReserved);
    
    [Flags]
    private enum ConnectedStateFlag : int
    {
        Configured = 0x40,
        LAN = 0x02,
        RasInstalled = 0x10,
        Modem = 0x01,
        ModemBusy = 0x08,
        Offline = 0x20,
        Proxy = 0x04
    }
