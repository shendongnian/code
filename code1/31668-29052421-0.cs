    //we will call this interface in our viewmodels
    public interface IDialogService
    {
        bool? ShowDialog(object dialogViewModel, string caption);
    }
    //we need to display logindialog from mainwindow
    public class MainWindowViewModel : ViewModelBase
    {
        public string Message {get; set;}
        public void ShowLoginCommandExecute()
        {
            var loginViewModel = new LoginViewModel();
            var dialogResult = this.DialogService.ShowDialog(loginViewModel, "Please, log in");
            //after dialog is closed, do someting
            if (dialogResult == true && loginViewModel.IsLoginSuccessful)
            {
                this.Message = string.Format("Hello, {0}!", loginViewModel.Username);
            }
        }
    }
    public class DialogService : IDialogService
    {
        public bool? ShowDialog(object dialogViewModel, string caption)
        {
            var contentView = ViewLocator.GetView(dialogViewModel);
            var dlg = new DialogWindow
            {
                Title = caption
            };
            dlg.PART_ContentControl.Content = contentView;
            return dlg.ShowDialog();
        }
    }
