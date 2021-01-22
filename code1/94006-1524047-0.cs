    public enum GWL
    {
        ExStyle = -20
    }
    public enum WS_EX
    {
        Transparent = 0x20,
        Layered = 0x80000
    }
    public enum LWA
    {
        ColorKey = 0x1,
        Alpha = 0x2
    }
    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);
    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);
    [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
    public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        int wl = GetWindowLong(this.Handle, GWL.ExStyle);
        wl = wl | 0x80000 | 0x20;
        SetWindowLong(this.Handle, GWL.ExStyle, wl);
        SetLayeredWindowAttributes(this.Handle, 0, 128, LWA.Alpha);
    }
