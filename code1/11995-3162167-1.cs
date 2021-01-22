    protected override System.Windows.Forms.CreateParams CreateParams
    {
        get
        {
            var parms = base.CreateParams;
            parms.Style &= ~0x00C00000; // remove WS_CAPTION
            parms.Style |= 0x00040000;  // include WS_SIZEBOX
            return parms;
        }
    }
