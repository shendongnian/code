    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                AttachCustomBehaviors();
            }
    
            // There's a better way of doing this, read attached behavior in wpf
            private void AttachCustomBehaviors()
            {
                TextBoxA.MouseEnter += (s, args) => ChangeMainWindowBackground(this, Brushes.LightBlue);
                TextBoxB.MouseEnter += (s, args) => ChangeMainWindowBackground(this, Brushes.LightGreen);
                TextBoxA.MouseLeave += (s, args) => ChangeMainWindowBackground(this, Brushes.Gray);
                TextBoxB.MouseLeave += (s, args) => ChangeMainWindowBackground(this, Brushes.Gray);
            }
    
            private static void ChangeMainWindowBackground(Window window, SolidColorBrush color)
            {
                window.Background = color;
            }
        }
    }
