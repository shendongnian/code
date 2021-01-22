    // sample of how you control navigation in the TabControl
    // by using the CanNavigate Dictionary in the TabControl 'Selecting event
    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
    {
      e.Cancel = ! CanNavigateDict[e.TabPage];
    }
