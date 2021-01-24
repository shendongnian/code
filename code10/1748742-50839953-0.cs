    public interface IDialogService
    {
        Task ShowMessageAsync(string message);
    }
    public class DialogService
    {
        public async Task ShowMessageAsync(string message)
        {
            MessageDialog messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }
    }
