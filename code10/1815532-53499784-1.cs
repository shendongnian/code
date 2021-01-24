    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataItems = new ObservableCollection<DataItem>();
            TheDataGrid.ItemsSource = DataItems;
            LoadDataItems();
        }
        public ObservableCollection<DataItem> DataItems { get; }
        private void LoadDataItems()
        {
            DataItems.Add(new DataItem(1,"One"));
            DataItems.Add(new DataItem(2, "Two"));
            DataItems.Add(new DataItem(3, "Three"));
            DataItems.Add(new DataItem(4, "Four"));
            DataItems.Add(new DataItem(5, "Five"));
        }
    }
