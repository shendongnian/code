    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TestItem selectedTestItem;
        public TestItem SelectedTestItem
        {
            get { return selectedTestItem; }
            set
            {
                selectedTestItem = value;
                RaisePropertyChanged("SelectedTestItem");
            }
        }
        private List<TestItem> _testItems;
        public List<TestItem> TestItems
        {
            get { return _testItems; }
            set
            {
                _testItems = value;
                RaisePropertyChanged("TestItems");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            var items = new List<TestItem>()
                    {
                        new TestItem() { Name = "Test1" },
                        new TestItem() { Name = "Test2" }
                    };
            TestItems = items;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
