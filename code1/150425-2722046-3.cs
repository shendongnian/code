    public static class UserDll
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
        public static void FlashWindow(System.Windows.Forms.Form window)
        {
            FlashWindow(window.Handle, false);
        }
    }
