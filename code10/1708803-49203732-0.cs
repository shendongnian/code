    private bool isNavigationConfirmed = false;
    protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (isNavigationConfirmed)
        {
            isNavigationConfirmed = false;
            return;
        }
        e.Cancel = true;
    
        var noCommand = new UICommand("No", cmd => { });
        var yesCommand = new UICommand("Yes", cmd =>
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                Frame.GoBack();
            }
            else
            {
                isNavigationConfirmed = true;
                Frame.Navigate(e.SourcePageType);
            }
        });
    
        var dialog = new MessageDialog("Do you want to allow navigation?");
        dialog.Options = MessageDialogOptions.None;
        dialog.Commands.Add(yesCommand);
        dialog.Commands.Add(noCommand);
        await dialog.ShowAsync();
    }
