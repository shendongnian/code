    public void Show(IWin32Window owner)
    {
        if (owner == this)
        {
            throw new InvalidOperationException(SR.GetString("OwnsSelfOrOwner", new object[] { "Show" }));
        }
        if (base.Visible)
        {
            throw new InvalidOperationException(SR.GetString("ShowDialogOnVisible", new object[] { "Show" }));
        }
        // here!!!
        if (!base.Enabled)
        {
            throw new InvalidOperationException(SR.GetString("ShowDialogOnDisabled", new object[] { "Show" }));
        }
        if (!this.TopLevel)
        {
            throw new InvalidOperationException(SR.GetString("ShowDialogOnNonTopLevel", new object[] { "Show" }));
        }
        if (!SystemInformation.UserInteractive)
        {
            throw new InvalidOperationException(SR.GetString("CantShowModalOnNonInteractive"));
        }
        if (((owner != null) && ((((int) UnsafeNativeMethods.GetWindowLong(new HandleRef(owner, Control.GetSafeHandle(owner)), -20)) & 8) == 0)) && (owner is Control))
        {
            owner = ((Control) owner).TopLevelControlInternal;
        }
