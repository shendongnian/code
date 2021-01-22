    private System.Windows.Forms.TabControl _tabControl;
    private System.Windows.Forms.TabPage _tabPage1;
    private System.Windows.Forms.TabPage _tabPage2;
    
    ...
    // Initialise the controls
    ...
    // "hides" tab page 2
    _tabControl.TabPages.Remove(_tabPage2);
    
    // "shows" tab page 2
    // if the tab control does not contain tabpage2
    if (! _tabControl.TabPages.Contains(_tabPage2))
    {
        _tabControl.TabPages.Add(_tabPage2);
    }
