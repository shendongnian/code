        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32.WM_SYSCOMMAND)
            {
                int test = m.WParam.ToInt32() & 0xFFF0;
                switch (test)
                {
                    case Win32.SC_MAXIMIZE:
                    case Win32.SC_RESTORE:
                        this.Invalidate();  // used to keep background image centered
                        break;
                }
            }
            base.WndProc(ref m);
        }
