    protected override CreateParams CreateParams {
        get {
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
            // Modify the existing style.
            CreateParams cp = base.CreateParams;
            // Remove the WS_CLIPCHILDREN flag.
            cp.Style &= ~0x02000000; // WS_CLIPCHILDREN value.
            return cp;
        }
    }
