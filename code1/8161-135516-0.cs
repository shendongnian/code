    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x20a)
        {
            int wheelDelta = ((int)m.WParam) >> 16;
    
            // 120 = UP 1 tick
            // -120 = DOWN 1 tick
    
            this.FirstDisplayedScrollingRowIndex -= (wheelDelta / 120);
        }
        else
        {
            base.WndProc(ref m);
        }
    }
