    public Task MsgBox(string title, string content)
    {
        Task T = Task.Run(async () =>
        {
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
                try{await msgbox.ShowAsync();}
                catch {/*reentrant calls invalid for contentdialog*/}
            });
        });
        return T;
    }
    private void B1BtnBack_Click(object sender, RoutedEventArgs e)
    {
        MsgBox("Beep", "Already at the top of stack");
        return; 
        // ^^^ Careful here. MsgBox returns with an active task
        // running to display dialog box.  This works because
        // the next statement is a return that directly 
        // returns to the UI message loop.  And the 
        // ContentDialog is model meaning it disables 
        // the page until ok is clicked in the dialog box.
    }
