    public static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("User32")]
        internal static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
    }
