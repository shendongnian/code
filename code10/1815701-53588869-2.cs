    private async void OnShowContentDialogExButtonClick(object sender, RoutedEventArgs e)
    {
        var dialog = new ContentDialogTest
        {
            Title = "Demo",
            Content = new Dialog(),
    
            PrimaryButtonText = "Primary",
            SecondaryButtonText = "Secondary",
            CloseButtonText = "Close"
        };
    
        await dialog.ShowAsync();
    }
