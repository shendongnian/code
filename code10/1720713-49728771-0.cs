    private async void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        e.Handled = true;
        MessageDialog dialog = new MessageDialog("Unhandled Execption", "Exception");
        await dialog.ShowAsync();
        Application.Exit();
    }
