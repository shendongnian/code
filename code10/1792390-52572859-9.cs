    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public Rectangle ToRectangle() => Rectangle.FromLTRB(Left, Top, Right, Bottom);
    }
    [SuppressUnmanagedCodeSecurity, SecurityCritical]
    internal static class SafeNativeMethods
    {
        [DllImport("User32.dll", SetLastError = true)]
        internal static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    }
    //Helper methods
    [SecuritySafeCritical]
    public static IntPtr FindWindowByClassName(IntPtr hwndParent, string lpszClass)
    {
        return SafeNativeMethods.FindWindowEx(hwndParent, IntPtr.Zero, lpszClass, null);
    }
    [SecuritySafeCritical]
    public static Rectangle GetWindowRectangle(IntPtr windowHandle)
    {
        RECT rect;
        new UIPermission(UIPermissionWindow.AllWindows).Demand();
        SafeNativeMethods.GetWindowRect(windowHandle, out rect);
        return rect.ToRectangle();
    }
