    if (this.WindowState == WindowState.Normal)
    {
        Properties.Settings.Default.Top = Top;
        Properties.Settings.Default.Left = Left;
        Properties.Settings.Default.Height = Height;
        Properties.Settings.Default.Width = Width;
    }
    else
    {
        Properties.Settings.Default.Top = RestoreBounds.Top;
        Properties.Settings.Default.Left = RestoreBounds.Left;
        Properties.Settings.Default.Height = RestoreBounds.Height;
        Properties.Settings.Default.Width = RestoreBounds.Width;
        // Check for WindowState.Maximized or WindowState.Minimized if you
        // need to do something different for each case (e.g. store if application
        // was Maximized
    }
