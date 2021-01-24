    public event EventHandler SetFullscreen;
	
	private async void fullscreen_Click(object sender, RoutedEventArgs e)
    {
		SetFullscreen.Invoke(this, null);
        if (!fullScreen)
        {
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
            mainPageBackup = (Window.Current.Content as Frame).Content as MainPage;
            (Window.Current.Content as Frame).Content = this;
        }
        else
        {
            ApplicationView.GetForCurrentView().ExitFullScreenMode();
            (Window.Current.Content as Frame).Content = mainPageBackup;
        }
    }
