        private const int WM_ACTIVATEAPP = 0x1C;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ACTIVATEAPP)
            {
                if (m.WParam == IntPtr.Zero)
                    Text = "Deactivated";
                else
                    Text = "Activated";
            }
            base.WndProc(ref m);
        }
