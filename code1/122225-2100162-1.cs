    public partial class Window1 : Window
    {
        ObservableCollection<string> items = new ObservableCollection<string>()
        {
            "string1","string2","string3","string4","string5"
        };
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
            tree.ItemsSource = items;
            items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(items_CollectionChanged);
        }
    
        void items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Event raised");
        }
    
     
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            items.Add("string6");
        }
    }
