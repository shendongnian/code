    protected void Minimize()
    {
        Hide();
    }
    protected void Maximize()
    {
        Show();
        this.WindowState =WindowState.Normal;
    }
    protected void EndApplication()
    {
        Minimize();
        Thread.Sleep(1000);
        _ForceClose = true;
        WindowState = WindowState.Normal;
        this.Close();
        Environment.Exit(0);
    }
