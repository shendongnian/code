            protected override void WndProc(ref Message m)
            {
                if (m.Msg == (int)0x102 && m.WParam.ToInt32() == 13)
                {
                    return;
                }
    
                base.WndProc(ref m);
            }
