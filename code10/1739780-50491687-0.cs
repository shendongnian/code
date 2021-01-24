    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            button.IsEnabled = false;
        }
        … handle button click
        if (button != null)
        {
            button.IsEnabled = true;
        }
    }
