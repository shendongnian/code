    private void SplashScreen_ContentRendered(object sender, EventArgs e)
    {
        // User authentication...
        // ...
        MainWindow mainWindow = new MainWindow();
        SetBinding(SplashScreen.TopmostProperty, new Binding("IsVisible"))
        {
            Source = mainWindow,
            Mode = BindingMode.OneWay,
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        };
        mainWindow.Show();
    }
