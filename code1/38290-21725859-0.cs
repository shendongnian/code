    public class MyLabel : Label
    {
        private bool fTransparent = false;
        public bool Transparent
        {
            get { return fTransparent; }
            set { fTransparent = value; }
        }
        public MyLabel() : base()
        {
        }
        protected override CreateParams CreateParams
        {
            get
            {
                if (fTransparent)
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                    return cp;
                }
                else return base.CreateParams;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (fTransparent)
            {
                if (m.Msg != 0x14 /*WM_ERASEBKGND*/ && m.Msg != 0x0F /*WM_PAINT*/)
                    base.WndProc(ref m);
                else 
                {
                    if (m.Msg == 0x0F) // WM_PAINT
                        base.OnPaint(new PaintEventArgs(Graphics.FromHwnd(Handle), ClientRectangle));
                    DefWndProc(ref m);
                }
            }
            else base.WndProc(ref m);
        }
    }
