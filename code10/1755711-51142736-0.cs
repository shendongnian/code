    AsyncAutoResetEvent resetEvent = new AsyncAutoResetEvent();
    private async void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Starting lost focus");
        await Task.Delay(3000);
        resetEvent.Set();
        Debug.WriteLine("Leaving lost focus");
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Clicking button");
        await resetEvent.WaitAsync();
        Debug.WriteLine("Finishing with click event");
    }
