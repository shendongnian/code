    public Task<ContentDialogResult> MsgBox(string title, string content)
    {
        Task<ContentDialogResult> X = null;
        var msgbox = new ContentDialog
        {
            Title = title,
            Content = content,
            CloseButtonText = "OK"
        };
        try
        {
            X = msgbox.ShowAsync().AsTask<ContentDialogResult>();
            X.Start();
        }
        catch { 
            return null;
        }
        return X;
    }
    private void B1BtnBack_Click(object sender, RoutedEventArgs e)
    {
        MsgBox("Beep", "Already at the top of stack");
        return; 
        // ^^^ Careful here. MsgBox returns with an active task
        // running to display dialog box.  This works because
        // the next statement is a return that directly 
        // returns to the UI message loop.  And the 
        // ContentDialog is modal meaning it disables 
        // the page until ok is clicked in the dialog box.
    }
