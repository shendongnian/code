    public static DialogHelpers
    {
        public static async Task ShowMessageAsync(string message)
        {
           MessageDialog messageDialog = new MessageDialog(message);
           await messageDialog.ShowAsync();
        }
    }
