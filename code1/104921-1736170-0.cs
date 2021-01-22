    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
    
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }
    
    [DllImport("user32.dll")]
    static extern uint GetCursorPos(out POINT lpPoint);    
    
    private void gridPersons_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        // check here if this is the cell with a check box
    
        gridPersons.BeginEdit();
        POINT point;
        GetCursorPos(out point);
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, point.X, point.Y, 0, 0);
    }
