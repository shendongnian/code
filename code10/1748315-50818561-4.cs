    [DllImport("CPlusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr GetServerPluginInterface();
    public static void RemoteConnectionRequestTest(IntPtr caller, string ip, ref int accept)
    {
        Console.WriteLine("C#: ip = {0}", ip);
        accept = 1;
    }
    public class Callbacks
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnRemoteConnectionRequestDelegate(IntPtr caller, [MarshalAs(UnmanagedType.LPWStr)]string ip, ref int accept);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void StartServerDelegate();
        public OnRemoteConnectionRequestDelegate RemoteConnectionRequest { get; set; }
        public StartServerDelegate StartServer { get; set; }
    }
