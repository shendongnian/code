    [UIPermission(SecurityAction.Demand, Action = SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
    public static Rectangle GetWindowRectangle(IntPtr WindowHandle)  {
        SafeNativeMethods.GetWindowRect(WindowHandle, out RECT rect);
        return rect.ToRectangle();
    }
    [UIPermission(SecurityAction.Demand, Action = SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
    public static Rectangle GetWindowClientRectangle(IntPtr WindowHandle)  {
        SafeNativeMethods.GetClientRect(WindowHandle, out RECT rect);
        SafeNativeMethods.ClientToScreen(WindowHandle, out POINT point);
        return rect.ToRectangleOffset(point);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public Rectangle ToRectangle() => Rectangle.FromLTRB(Left, Top, Right, Bottom);
        public Rectangle ToRectangleOffset(POINT p) => Rectangle.FromLTRB(p.x, p.y, Right + p.x, Bottom + p.y);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
	    [DllImport("User32.dll", SetLastError = true)]
	    internal static extern bool ClientToScreen(IntPtr hWnd, out POINT point);
        [DllImport("User32.dll", SetLastError = true)]
	    internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
	
	    [DllImport("User32.dll", SetLastError = true)]
	    internal static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
    }
