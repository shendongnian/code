    public interface IMessageBox
        {
            /// <summary>Displays a message box that has a message, title bar caption, and button; and that returns a result.</summary>          
            MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);
        /// <summary>Displays a message box that has a message, title bar caption, button, and icon; and that returns a result.</summary>           
        MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);
        /// <summary>Displays a message box that has a message and title bar caption; and that returns a result.</summary>            
        MessageBoxResult Show(string messageBoxText, string caption);
    }
