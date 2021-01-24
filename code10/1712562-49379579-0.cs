        private const int SC_MAXIMIZE = 0xF030;
        private const int WM_SYSCOMMAND = 0x0112;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam == new IntPtr(SC_MAXIMIZE))
                {
                    this.Size = this.MaximumSize;
                    return;
                }
            }
            base.WndProc(ref m);
        }
