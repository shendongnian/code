        private void AdjustClientRect(ref RECT rcClient)
        {
            rcClient.Left += 10;
            rcClient.Top += 10;
            rcClient.Right -= 10;
            rcClient.Bottom -= 10;
        }
        struct RECT { public int Left, Top, Right, Bottom; }
        struct NCCALCSIZE_PARAMS
        {
            public RECT rcNewWindow;
            public RECT rcOldWindow;
            public RECT rcClient;
            IntPtr lppos;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            const int WM_NCCALCSIZE = 0x0083;
            if (m.Msg == WM_NCCALCSIZE)
            {
                if (m.WParam != IntPtr.Zero)
                {
                    NCCALCSIZE_PARAMS rcsize = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                    AdjustClientRect(ref rcsize.rcNewWindow);
                    Marshal.StructureToPtr(rcsize, m.LParam, false);
                }
                else
                {
                    RECT rcsize = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                    AdjustClientRect(ref rcsize);
                    Marshal.StructureToPtr(rcsize, m.LParam, false);
                }
                m.Result = new IntPtr(1);
                return;
            }
        }
