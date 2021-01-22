    protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
    
                if(m.Msg == 0x0047) // WM_WINDOWPOSCHANGED = 0x0047
                {
                    if (SelectionLength != 0)
                    {
                        SelectionLength = 0;
                    }
                }
            } 
