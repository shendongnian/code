    using System.Windows;
    using System.Windows.Input;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Window_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.System && (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)))
                    e.Handled = true;
            }
        }
    }
