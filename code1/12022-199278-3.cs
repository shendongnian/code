    const int WM_ERASEBKGND = 0x14;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if(m.Msg == WM_ERASEBKGND)
        {
            using(var g = Graphics.FromHdc(m.WParam))
            {
                using(var b = new SolidBrush(_backColor))
                {
                    g.FillRectangle(b, ClientRectangle);
                }
            }
            return;
        }
        base.WndProc(ref m);
    }
