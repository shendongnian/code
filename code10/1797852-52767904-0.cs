           static extern bool WTSSendMessage(
                  IntPtr hServer,
                  [MarshalAs(UnmanagedType.I4)] int SessionId,
                  String pTitle,
                  [MarshalAs(UnmanagedType.U4)] int TitleLength,
                  String pMessage,
                  [MarshalAs(UnmanagedType.U4)] int MessageLength,
                  [MarshalAs(UnmanagedType.U4)] int Style,
                  [MarshalAs(UnmanagedType.U4)] int Timeout,
                  [MarshalAs(UnmanagedType.U4)] out int pResponse,
                  bool bWait);
        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern int WTSGetActiveConsoleSessionID();
        public static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        public static int WTS_CURRENT_SESSION = 1;
        
            public static void Show_Message()
            {
                bool result = false;
                string title = "Aviso";
                int tlen = title.Length;
                string msg = "Service ended !";
                int mlen = msg.Length;
                int resp = 0;
    
                result = WTSSendMessage(WTS_CURRENT_SERVER_HANDLE, WTS_CURRENT_SESSION, title, tlen, msg, mlen, 0, 0, out resp, true);
                //int err = Marshal.GetLastWin32Error();
                //System.Console.WriteLine("result:{0}, errorCode:{1}, response:{2}", result, err, resp);
    
    
            }
