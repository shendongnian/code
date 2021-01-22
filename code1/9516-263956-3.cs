    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        Properties.Settings.Default.Save();
        base.OnClosing(e); 
    }
