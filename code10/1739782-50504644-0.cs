    public static class ContentDialogMaker
    {
        public static async void CreateContentDialog(ContentDialog Dialog, bool awaitPreviousDialog) { await CreateDialog(Dialog, awaitPreviousDialog); }
        public static async Task CreateContentDialogAsync(ContentDialog Dialog, bool awaitPreviousDialog) { await CreateDialog(Dialog, awaitPreviousDialog); }
    
        static async Task CreateDialog(ContentDialog Dialog, bool awaitPreviousDialog)
        {
            if (ActiveDialog != null)
            {
                if (awaitPreviousDialog)
                {
                    ActiveDialog.Hide();
                }
                else
                {
                    switch (Info.Status)
                    {
                        case AsyncStatus.Started:
                            Info.Cancel();
                            break;
                        case AsyncStatus.Completed:
                            Info.Close();
                            break;
                        case AsyncStatus.Error:
    
                            break;
                        case AsyncStatus.Canceled:
    
                            break;
                    }
                }
            }
            ActiveDialog = Dialog;
            ActiveDialog.Closing += ActiveDialog_Closing;
            Info = ActiveDialog.ShowAsync();
        }
        public static IAsyncInfo Info;
        private static void ActiveDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            ActiveDialog = null;
        }
    
        public static ContentDialog ActiveDialog;
    }
