    private async void button_Click(object sender, RoutedEventArgs e)
    {
        this.button.IsEnabled = false;
        TimeSpan runningTime = new TimeSpan();
        await Task.Run(() => 
        {
            this.TimeConsumingOperation();
        });
        this.label.Content = string.Format("The time-consuming operation took {0} seconds", runningTime.TotalSeconds);
        this.button.IsEnabled = true;
    }
