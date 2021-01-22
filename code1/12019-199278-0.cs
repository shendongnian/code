    const int WM_ERASEBKGND = 0x14;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
         if(m.Msg == WM_ERASEBKGND)
         {
           Graphics g = Graphics.FromHdc(m.WParam);
           g.FillRectangle(new SolidBrush(_backColor), ClientRectangle);
           g.Dispose();
         }
    }
