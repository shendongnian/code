    if (WindowState == WindowState.Maximized)
    {
        // Use the RestoreBounds as the current values will be 0, 0 and the size of the screen
        Properties.Settings.Default.Top = RestoreBounds.Top;
        Properties.Settings.Default.Left = RestoreBounds.Left;
        Properties.Settings.Default.Height = RestoreBounds.Height;
        Properties.Settings.Default.Width = RestoreBounds.Width;
        Properties.Settings.Default.Maximized = true;
    }
    else
    {
        Properties.Settings.Default.Top = this.Top;
        Properties.Settings.Default.Left = this.Left;
        Properties.Settings.Default.Height = this.Height;
        Properties.Settings.Default.Width = this.Width;
        Properties.Settings.Default.Maximized = false;
    }
    Properties.Settings.Default.Save();
