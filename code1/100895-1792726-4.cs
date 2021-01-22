    protected override void WndProc(ref Message m)
    {
        int _iWParam = (int)m.WParam;
        int _iLParam = (int)m.LParam;
        switch ((ECGCardioCard.APIMessage)m.Msg)
        {
                // handling code goes here
        }
        base.WndProc(ref m);
    }
