    //using System.Runtime.InteropServices;
    public const int GCL_STYLE = -26;
    public const int CS_DROPSHADOW = 0x20000;
    [DllImport("user32.dll", EntryPoint = "GetClassLong")]
    public static extern int GetClassLong(IntPtr hWnd, int nIndex);
    [DllImport("user32.dll", EntryPoint = "SetClassLong")]
    public static extern int SetClassLong(IntPtr hWnd, int nIndex, int dwNewLong);
    private void toolTip1_Popup(object sender, PopupEventArgs e) 
    {
        e.ToolTipSize = new Size(100, 100);
        var hwnd = (IntPtr)typeof(ToolTip).GetProperty("Handle",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance).GetValue(toolTip);
        var cs = GetClassLong(hwnd, GCL_STYLE);
        if ((cs & CS_DROPSHADOW) == CS_DROPSHADOW)
        {
            cs = cs & ~CS_DROPSHADOW;
            SetClassLong(hwnd, GCL_STYLE, cs);
        }
    }
