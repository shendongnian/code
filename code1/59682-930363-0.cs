    protected override void WndProc(ref Message message)
    {
        const int WM_NCHITTEST = 0x0084;
        switch (message.Msg)
        {
            case WM_NCHITTEST:
                return;
                break;
        }
        base.WndProc(ref message);
    }
