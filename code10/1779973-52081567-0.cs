    public sealed partial class MainPage : Page
    {
        private ObservableCollection<ListItem> ListItems;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPageLoaded; //if you dont want to use loaded method u can use OnnavigatedTo() override as well.
            ObservableCollection<ListItem> ListItems = new ObservableCollection<ListItem>();
        }
        private async void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            await ThisMethod();
        }
        private async Task ThisMethod()
        {
            MyProgress.Visibility = Visibility.Visible;
            var items = await ListManager.GetItemsAsync();
            foreach(var item in items)
            {
                ListItems.Add(item);
            }
            MyProgress.Visibility = Visibility.Collapsed;
        }
    }
