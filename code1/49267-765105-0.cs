        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_WINSOCK_ASYNC_MSG)
            {
                // invoke your method
            }
            else
            {
                base.WndProc(ref m);
            }
        }
