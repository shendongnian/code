    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var options = new Windows.System.LauncherOptions();
        options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseMinimum;
        var success = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-inputapp:"), options);
    }
