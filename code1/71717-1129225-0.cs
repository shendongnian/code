        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_CLOSE)
            {
                //PROCESS IT
            }
        }
