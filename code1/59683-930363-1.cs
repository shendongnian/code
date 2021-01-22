    protected override void WndProc(ref m message)
    {
        const int WM_NCHITTEST = 0x0084;
        switch (m.Msg)
        {
            case WM_NCHITTEST:
                return;
        }
        base.WndProc(ref message);
    }
