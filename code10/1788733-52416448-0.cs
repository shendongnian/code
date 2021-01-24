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
        }
    
    
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          NavigationWindow window = new NavigationWindow();
          window.Source = new Uri("Page1.xaml", UriKind.Relative);
          window.Show();
        }
    
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          NavigationWindow window = new NavigationWindow();
          window.Source = new Uri("Page2.xaml", UriKind.Relative);
          window.Show();
        }
    
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
          NavigationWindow window = new NavigationWindow();
          window.Source = new Uri("Page3.xaml", UriKind.Relative);
          window.Show();
        }
    }
    }
