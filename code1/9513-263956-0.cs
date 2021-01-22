    protected override void OnClosing(System.ComponentModel.CancelEventArgse)
    {
        Settings.Default.Save();
        base.OnClosing(e); 
    }
