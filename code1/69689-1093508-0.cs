    #region Dirty methods :)
    #pragma warning disable 169
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        
    private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    private const int MOUSEEVENTF_MOVE = 0x1;
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;
    #pragma warning restore 169
    #endregion
        
    private void button1_Click(object sender, EventArgs e) {
       Point oldCursorPos = Cursor.Position; // save pos
       Point a = comboBox1.Parent.PointToScreen(comboBox1.Location);
       a.X += comboBox1.Width - 3;
       a.Y += comboBox1.Height - 3;
       Cursor.Position = a;
       // simuate click on drop down button
       mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
       Cursor.Position = oldCursorPos; // restore pos
    }
