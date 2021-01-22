     using System;
     using System.Text;
     using System.Windows;
     using System.Windows.Controls;
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
    }
    
