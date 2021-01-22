    public bool ClosedByXButtonOrAltF4 {get; private set;}
    private const int SC_CLOSE = 0xF060;
    private const int WM_SYSCOMMAND = 0x0112;
    protected override void WndProc(ref Message msg)
    {
        if (msg.Msg == WM_SYSCOMMAND && msg.WParam.ToInt32() == SC_CLOSE)
            ClosedByXButtonOrAltF4 = true;
        base.WndProc(ref msg);
    }
    protected override void OnShown(EventArgs e)
    {
        ClosedByXButtonOrAltF4 = false;
    }   
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (ClosedByXButtonOrAltF4)
            MessageBox.Show("Closed by X or Alt+F4");
        else
            MessageBox.Show("Closed by calling Close()");
    }
