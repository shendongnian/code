    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public MainPage()
        {
            InitializeComponent();
            for (int i=1; i<11; i++)
            {
                Item item = new Item { ItemName = $"Item {i}", Count = "5" };
                Items.Add(item);
            }
            BindingContext = this;
        }
    }
