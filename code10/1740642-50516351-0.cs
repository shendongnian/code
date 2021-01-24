    private async void startButton(object sender, RoutedEventArgs e)
    {
        CancelEnabled = true;
        await start();
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        btnTest.IsEnabled = false;
        await Dowork();
        btnTest.IsEnabled = true;
    }
    private async Task Dowork()
    {
        await Task.Delay(1000);
    }
