    namespace UWPListView
    {
        public sealed partial class MainPage : Page
        {
            public ObservableCollection<ListItem> Model; // change your XAML to bind to Model instead of ListItems
    
            public MainPage()
            {
                this.InitializeComponent();
                this.Loaded += new RoutedEventHandler(OnLoaded);
            }
            private async void OnLoaded(object sender, RoutedEventArgs e)
            {
                MyProgress.Visibility = Visibility.Visible;
                this.Model = await ListManager.GetItemsAsync();
                MyProgress.Visibility = Visibility.Collapsed;
            } 
        }
    }
