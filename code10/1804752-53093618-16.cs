    public static class OpenWindowGetter
    {
        public static IDictionary<string, IntPtr> GetOpenWindowsByProcessId(int processId)
        {
            IntPtr shellWindow = GetShellWindow();
            Dictionary<string, IntPtr> windows = new Dictionary<string, IntPtr>();
            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                uint ownerProcessId;
                GetWindowThreadProcessId(hWnd, out ownerProcessId);
                if (ownerProcessId != processId)
                    return true;
                if (hWnd == shellWindow)
                    return true;
                if (!IsWindowVisible(hWnd))
                    return true;
                int length = GetWindowTextLength(hWnd);
                if (length == 0)
                    return true;
                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);
                windows[builder.ToString()] = hWnd;
                return true;
            }, 0);
            return windows;
        }
        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }
