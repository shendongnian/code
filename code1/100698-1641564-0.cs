    namespace YourNameSpaceHere
    {
        public partial class MainWindow : Window
        {
            internal static string message_ = string.Empty;
            MainWindow()
            {
                InitializeComponent();
                SetupMessage();
            }
    
            private void SetupMessage()
            {
                message_ = "Hello World!";
            }
        }
    
    
        public class Messaging
        {
            Messaging()
            {
                MessageBox.Show(MainWindow.message_);
            }
        }
    }
