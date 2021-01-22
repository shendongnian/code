    [DllImport("user32", EntryPoint = "OpenDesktopA", CharSet = CharSet.Ansi,SetLastError = true, ExactSpelling = true)]
        private static extern Int32 OpenDesktop(string lpszDesktop, Int32 dwFlags, bool fInherit, Int32 dwDesiredAccess);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 CloseDesktop(Int32 hDesktop);
        [DllImport("user32", CharSet = CharSet.Ansi,SetLastError = true,ExactSpelling = true)]
        private static extern Int32 SwitchDesktop(Int32 hDesktop);
        public static bool IsWorkstationLocked()
        {
            const int DESKTOP_SWITCHDESKTOP = 256;
            int hwnd = -1;
            int rtn = -1;
            hwnd = OpenDesktop("Default", 0, false, DESKTOP_SWITCHDESKTOP);
            if (hwnd != 0)
            {
                rtn = SwitchDesktop(hwnd);
                if (rtn == 0)
                {
                    // Locked
                    CloseDesktop(hwnd);
                    return true;
                }
                else
                {
                    // Not locked
                    CloseDesktop(hwnd);
                }
            }
            else
            {
                // Error: "Could not access the desktop..."
            }
            return false;
        }
