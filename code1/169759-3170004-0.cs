    class MyMessageBox : Window
    {
        // perhaps a helper method here
        public static bool? Show(String message, Image image)
        {
            // Message and Image are fields created in the XAML markup
            var msgBox = new MyMessageBox() { Message = message, Image = image };
            return msgBox.ShowDialog();
        }
    }
