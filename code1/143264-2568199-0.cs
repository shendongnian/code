    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    //winuser.h constants
    private const int WM_VSCROLL = 277; // Vertical scroll
    private const int SB_LINEUP = 0;    // Scrolls one line up
    private const int SB_LINEDOWN = 1;  // Scrolls one line down
    private const int SB_ENDSCROLL = 8; // Ends the scrolling
    //Call this when you want to scroll
    private void ScrollGridview(int direction)
    {
        IntPtr scrollbarHandle = GetScrollbarHandle();
        SendMessage(dataGridView.Handle, WM_VSCROLL, (IntPtr)direction, scrollbarHandle );
        SendMessage(dataGridView.Handle, WM_VSCROLL, (IntPtr)SB_ENDSCROLL, scrollbarHandle);
    }
    private IntPtr GetScrollbarHandle()
    {
        foreach(Control control in dataGridView.Controls)
        {
            if(control is VScrollBar)
                return control.Handle;
        }
        return IntPtr.Zero;
    }
