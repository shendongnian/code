    switch (this.WindowState)
    {
        case WindowState.Maximized:
            Properties.Settings.Default.Top = RestoreBounds.Top;
            Properties.Settings.Default.Left = RestoreBounds.Left;
            Properties.Settings.Default.Height = RestoreBounds.Height;
            Properties.Settings.Default.Width = RestoreBounds.Width;
            Properties.Settings.Default.Maximised = true;
            break;
        case WindowState.Minimized:
            Properties.Settings.Default.Top = RestoreBounds.Top;
            Properties.Settings.Default.Left = RestoreBounds.Left;
            Properties.Settings.Default.Height = RestoreBounds.Height;
            Properties.Settings.Default.Width = RestoreBounds.Width;
            Properties.Settings.Default.Maximised = false;
            break;
        case WindowState.Normal:
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Height = Height;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Maximised = false;
            break;
    }
