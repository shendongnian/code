    protected override void OnClosing(System.ComponentModel.CancelEventArgse)
    {
        Properties.Settings.Default.Save();
        base.OnClosing(e); 
    }
