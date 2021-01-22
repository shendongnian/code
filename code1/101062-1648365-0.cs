    public delegate void NotifyFunc(enumType notificationType, IntPtr data);
    
    [DllImport("VssSdkd")]
    public static extern void startVssSdkClientEcho(string IpAddress,
        long port, NotifyFunc notifyFunc, eProtocolType proType, bool Req);
