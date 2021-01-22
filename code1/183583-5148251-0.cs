    using System.Runtime.InteropServices;
    [DllImport("dnsapi.dll",EntryPoint="DnsFlushResolverCache")]
    private static extern UInt32 DnsFlushResolverCache ();
    public static void FlushMyCache() //This can be named whatever name you want and is the function you will call
    {
        UInt32 result = DnsFlushResolverCache();
    }
