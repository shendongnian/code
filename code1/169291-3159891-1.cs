    [DllImport("user32.dll", CharSet = CharSet.Auto, 
     CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(long dwFlags, long dx, long dy, 
        long cButtons, long dwExtraInfo);
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;
    public void ClickMouseLeftButton(Point globalLocation)
    {
        Point currLocation = Cursor.Position;
        Cursor.Position = globalLocation;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 
            globalLocation.X, globalLocation.Y, 0, 0);
        Cursor.Position = currLocation;
    }
    public void ClickControl(Control target, Point localLocation)
    {
        ClickMouseLeftButton(target.PointToScreen(localLocation));
    }
    public void ClickControl(Control target)
    {
        ClickControl(target, new Point(target.Width / 2, target.Height / 2));
    }
