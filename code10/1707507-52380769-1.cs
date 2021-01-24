    public class MessageBoxHelper : IMessageBox
        {
            /// <summary>Displays a message box that has a message, title bar caption, button, and icon; and that returns a result.</summary>            
            public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button,
                MessageBoxImage icon)
            {
                return MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.None,
                    MessageBoxOptions.None);
            }
        /// <summary>Displays a message box that has a message, title bar caption, and button; and that returns a result.</summary>            
        public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return MessageBox.Show(messageBoxText, caption, button, MessageBoxImage.None, MessageBoxResult.None,
                MessageBoxOptions.None);
        }
        /// <summary>Displays a message box that has a message and title bar caption; and that returns a result.</summary>            
        public MessageBoxResult Show(string messageBoxText, string caption)
        {
            return MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None,
                MessageBoxResult.None, MessageBoxOptions.None);
        }
        /// <summary>Displays a message box that has a message and that returns a result.</summary>           
        public MessageBoxResult Show(string messageBoxText)
        {
            return MessageBox.Show(messageBoxText, string.Empty, MessageBoxButton.OK, MessageBoxImage.None,
                MessageBoxResult.None, MessageBoxOptions.None);
        }
    }
