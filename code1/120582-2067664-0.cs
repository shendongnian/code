    // note : untested code : use caution ... test rigorously ...
    // stub for the Dictionary of monitored Controls
    private Dictionary<Control, int> LayoutManager_MonitoredControls = new Dictionary<Control, int>();
    // the SizeChanged Event Handler you "install" for all Controls you wish to monitor
    private void LayoutManager_SizeChanged(object sender, EventArgs e)
    {
        Control theControl = sender as Control;
        int cHeight = theControl.Height;
        if (LayoutManager_MonitoredControls[theControl] != theControl.Height);
        {
            // update the Dictionary
            LayoutManager_MonitoredControls[theControl] = cHeight;
            // call your code to update the Layout here ...
        }
    }
