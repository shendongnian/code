        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 3)
            {
                base.WndProc(ref m);
            }
        }
