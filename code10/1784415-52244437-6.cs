    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                AttachCustomBehaviors();
            }
    
            // There's a better way of doing this, read attached behavior in wpf
            private void AttachCustomBehaviors()
            {
                TextBoxA.GotFocus += (s, args) => ChangeMainWindowBackground(this, Brushes.LightBlue);
                TextBoxB.GotFocus += (s, args) => ChangeMainWindowBackground(this, Brushes.LightGreen);
                TextBoxA.LostFocus += (s, args) => ChangeMainWindowBackground(this, Brushes.Gray);
                TextBoxB.LostFocus += (s, args) => ChangeMainWindowBackground(this, Brushes.Gray);
            }
    
            private void InputFieldsHovered(object sender, MouseEventArgs e)
            {
                if (!TextBoxA.IsFocused && !TextBoxB.IsFocused)
                {
                    ChangeMainWindowBackground(this, Brushes.Gray);
                }
                else if(TextBoxA.IsFocused)
                {
                    ChangeMainWindowBackground(this, Brushes.LightBlue);
                }
                else if (TextBoxB.IsFocused)
                {
                    ChangeMainWindowBackground(this, Brushes.LightGreen);
                }
            }
    
            private static void ChangeMainWindowBackground(Window window, SolidColorBrush color)
            {
                window.Background = color;
            }
        }
    }
