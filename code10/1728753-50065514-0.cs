    /* declare Setting in this scope if you are going to use it multiple times */
    Setting _Setting;
    private void yourButtonName_OnClick(object sender, EventArgs e)
    {
        /* null and disposed checking to create a new instance when necessary */ 
        if (_Setting == null || _Setting.IsDisposed)
        {
            /* passing this form list to the Setting form */
            _Setting = new _Setting(this.List1);
        }
        /* calling the form through ShowDialog will make your MainForm to
        wait until Setting form is closed */
        _Setting.ShowDialog();
        /* setting the list value */
        this.List1 = _Setting.List;
        _Setting.Dispose();
    }
