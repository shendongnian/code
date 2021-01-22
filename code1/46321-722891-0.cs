    using System.Runtime.InteropServices;
    [DllImport("wininet.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public extern static bool InternetGetConnectedState(
        out int connectionDescription,
        int reservedValue);
    [DllImport("wininet.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.I4)]
    public static extern int InternetAttemptConnect(int dwReserved);
    public sealed class InternetConnection
    {
        private InternetConnection()
        { }
        public static bool IsConnected()
        {
            int connectionDescription = 0;
            return InternetGetConnectedState(out connectionDescription, 0);
        }
        public static int Connect()
        {
            return InternetAttemptConnect(0);
        }
    }
