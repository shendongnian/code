        public const long WS_POPUP = 0x80000000L;
        public static bool IsWindowPopup(IntPtr hHandle)
        {
            long style = WinAPI.GetWindowLongPtr(hHandle, -16);
            bool isPopup = ((style & WS_POPUP) != 0);
            return isPopup;
        }
 
