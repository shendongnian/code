    private const int WM_CLOSE = 0x0010;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_CLOSE)
        {
            var autoValidate = this.AutoValidate;
            this.AutoValidate = AutoValidate.Disable;
            base.WndProc(ref m);
            this.AutoValidate = autoValidate;
        }
        else
            base.WndProc(ref m);
    }
