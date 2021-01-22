    [DllImport("dhcpsapi.dll", CharSet = CharSet.Unicode)]
    internal static extern UInt32 DhcpEnumServers(
        UInt32 Flags, // Should be 0
        IntPtr IdInfo, // Should be null
        out IntPtr Servers,
        IntPtr CallbackFn, // Should be null
        IntPtr CallbackData // Should be null
        );
    [DllImport("dhcpsapi.dll")]
    internal static extern void DhcpRpcFreeMemory(IntPtr BuffPtr);
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct DHCP_SERVER_INFO_ARRAY
    {
        public UInt32 Flags;
        public UInt32 NumElements;
        public IntPtr Servers;
    }
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct DHCP_SERVER_INFO
    {
        public UInt32 Version;
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string ServerName;
        public UInt32 ServerAddress;
        public UInt32 Flags;
        public UInt32 State;
        [MarshalAsAttribute(UnmanagedType.LPWStr)]
        public string DsLocation;
        public UInt32 DsLocType;
    }
    public class DhcpServer
    {
        public string Name;
        public DhcpIpAddress IpAddress;
        public string AdLocation;
        public static List<DhcpServer> EnumAll()
        {
            var servers = new List<DhcpServer>();
            IntPtr retPtr;
            var response = NativeMethods.DhcpEnumServers(0, IntPtr.Zero, out retPtr, IntPtr.Zero, IntPtr.Zero);
            if (response != 0)
            {
                if (retPtr != IntPtr.Zero)
                {
                    NativeMethods.DhcpRpcFreeMemory(retPtr);
                }
                throw new DhcpException(response);
            }
            var nativeArray = (DHCP_SERVER_INFO_ARRAY) Marshal.PtrToStructure(retPtr, typeof (DHCP_SERVER_INFO_ARRAY));
            var current = nativeArray.Servers;
            for (var i = 0; i < nativeArray.NumElements; ++i)
            {
                var nativeClient = (DHCP_SERVER_INFO) Marshal.PtrToStructure(current, typeof (DHCP_SERVER_INFO));
                servers.Add(ConvertFromNative(nativeClient));
                current = (IntPtr) ((int) current + Marshal.SizeOf(typeof(DHCP_SERVER_INFO)));
            }
            NativeMethods.DhcpRpcFreeMemory(retPtr);
            return servers;
        }
        private static DhcpServer ConvertFromNative(DHCP_SERVER_INFO nativeServer)
        {
            var server = new DhcpServer
                             {
                                 IpAddress = new DhcpIpAddress(nativeServer.ServerAddress),
                                 Name = nativeServer.ServerName,
                                 AdLocation = nativeServer.DsLocation
                             };
            return server;
        }
    }
