    public void MsgBox(string title, string content)
    {
        Task.Run(async () =>
            await Dispatcher.RunAsync(
                   Windows.UI.Core.CoreDispatcherPriority.Normal, 
                   async () =>
            {
                var msgbox = new ContentDialog
                {
                    Title = title,
                    Content = content,
                    CloseButtonText = "OK"
                };
                await msgbox.ShowAsync();
        }));
    }
    private void B1BtnBack_Click(object sender, RoutedEventArgs e)
    {
        if (ContentFrame.CanGoBack)
        {
            ContentFrame.GoBack();
        }
        else
        {
            MsgBox("Beep", "Already at the top of stack");
        }
        return;
    }
