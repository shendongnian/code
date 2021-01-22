        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020; 
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MINIMIZE)
                    {
                        // Do your action
                    }
                    // If you don't want to do the default action then break
                    break;
            }
            base.WndProc(ref m);
        }
