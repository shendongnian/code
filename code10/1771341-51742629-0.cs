    private async void OnApplicationStarted(object sender, RoutedEventArgs e)
    {
        await Task.Delay((int)TimeSpan.FromMinutes(9).TotalMilliseconds);
        MessageBox.Show("1 minute left");
        await Task.Delay((int)TimeSpan.FromMinutes(1).TotalMilliseconds);
        MessageBox.Show("time over");
        Application.Exit();
    }
