    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var scaleRatio = Math.Max(Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.PrimaryScreenWidth,
                    Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.PrimaryScreenHeight);
        this.Left = Screen.AllScreens[1].WorkingArea.Left / scaleRatio ;
        this.Top = Screen.AllScreens[1].WorkingArea.Top / scaleRatio ;
    }
