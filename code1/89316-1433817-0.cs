    public static class Helper
    {
        public static IntPtr[] GetToplevelWindows()
        {
            List<IntPtr> windowList = new List<IntPtr>();
            GCHandle handle = GCHandle.Alloc(windowList);
            try
            {
                Helper.EnumWindows(Helper.EnumWindowsCallback, (IntPtr)handle);
            }
            finally
            {
                handle.Free();
            }
            return windowList.ToArray();
        }
        private delegate bool EnumWindowsCallBackDelegate(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.Dll")]
        private static extern int EnumWindows(EnumWindowsCallBackDelegate callback, IntPtr lParam);
        private static bool EnumWindowsCallback(IntPtr hwnd, IntPtr lParam)
        {
            ((List<IntPtr>)((GCHandle)lParam).Target).Add(hwnd);
            return true;
        }
    }
