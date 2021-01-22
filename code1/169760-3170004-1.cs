    public partial class MyMessageBox : Window
    {
        // perhaps a helper method here
        public static bool? Show(String message, BitmapImage image)
        {
            // NOTE: Message and Image are fields created in the XAML markup
            MyMessageBox msgBox = new MyMessageBox() { Message.Text = message, Image.Source = image };
            return msgBox.ShowDialog();
        }
    }
