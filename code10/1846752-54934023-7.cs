    using System.Windows;
    
    namespace SeveralDisplays
    {
        
        
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            
            public MainWindow()
            {
                InitializeComponent();
            }
            
            private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                ShowInTaskbar = false;
            }
        }
    }
