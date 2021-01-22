    public static class WinInetHelper
    {
        public static bool SupressCookiePersist()
        {
            // 3 = INTERNET_SUPPRESS_COOKIE_PERSIST 
            // 81 = INTERNET_OPTION_SUPPRESS_BEHAVIOR
            return SetOption(81, 3);
        }
        public static bool EndBrowserSession()
        {
            // 42 = INTERNET_OPTION_END_BROWSER_SESSION 
            return SetOption(42, null);
        }
        static bool SetOption(int settingCode, int? option)
        {
            IntPtr optionPtr = IntPtr.Zero;
            int size = 0;
            if (option.HasValue)
            {
                size = sizeof (int);
                optionPtr = Marshal.AllocCoTaskMem(size);
                Marshal.WriteInt32(optionPtr, option.Value);
            }
            bool success = InternetSetOption(0, settingCode, optionPtr, size);
            if (optionPtr != IntPtr.Zero) Marshal.Release(optionPtr);
            return success;
        }
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetSetOption(
            int hInternet,
            int dwOption,
            IntPtr lpBuffer,
            int dwBufferLength
        );
    }
