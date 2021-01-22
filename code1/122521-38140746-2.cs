    interface IDialogService
    {
       void Show(IDialogViewModel dialog);
       void Close(IDialogViewModel dialog); 
       bool? ShowModal(IDialogViewModel dialog);
       MessageBoxResult ShowMessageBox(string message, string caption = null, MessageBoxImage icon = MessageBoxImage.No...);
    }
    interface IDialogViewModel 
    {
        string Caption {get;}
        IEnumerable<DialogButton> Buttons {get;}
    }
