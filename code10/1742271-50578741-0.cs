    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await Iterate_balance();    
    }
    
    private async Task Iterate_balance()
    {
        button.Content = "Click to stop";
 
        await Task.Delay(TimeSpan.FromSeconds(4));
        button.Content = "Click to run";
    }
