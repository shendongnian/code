    using System.Threading.Tasks;
    using System.Windows;
    
    namespace Question_Answer_WPF_App
    {
        public partial class MainWindow : Window
        {
            public MainWindow() => InitializeComponent();
    
            private Task SimulateLoadingResourcesAsnyc() => Task.Delay(3000);
    
            private async void MenuButton_Click(object sender, RoutedEventArgs e)
            {
                menuItems.Visibility = Visibility.Collapsed;
                menuLoading.Visibility = Visibility.Visible;
    
                await SimulateLoadingResourcesAsnyc();
    
                menuItems.Visibility = Visibility.Visible;
                menuLoading.Visibility = Visibility.Collapsed;
            }
        }
    }
