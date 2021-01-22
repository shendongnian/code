    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
    private const int WM_VSCROLL = 0x115;
    private const int SB_LINEDOWN = 1;
    public Form1()
    {
        InitializeComponent();
        for (int i = 0; i < 100; i++)
            listView1.Items.Add("foo" + i);
        listView1.Scrollable = false;
    }
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SendMessage(listView1.Handle, WM_VSCROLL, SB_LINEDOWN, 0);
    }
