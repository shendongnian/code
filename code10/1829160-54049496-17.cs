    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<MyComboBoxItem> MyComboBoxItems { get; set; } = new List<MyComboBoxItem>()
        {
            new MyComboBoxItem() {Text = "Item1", Color = "Red"},
            new MyComboBoxItem() {Text = "Item2", Color = "Green"},
            new MyComboBoxItem() {Text = "Item3"},
        };
        private ObservableCollection<MyComboBoxItem> _activeUserControls;
        public ObservableCollection<MyComboBoxItem> ActiveUserControls
        {
            get => _activeUserControls;
            set { _activeUserControls = value; OnPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void OnSelectionChanged(object sender, MyComboBoxSelectionChangedEventArgs e)
        {
            if (e.MyComboBoxItem is MyComboBoxItem item)
            {
                if (ActiveUserControls == null)
                {
                    ActiveUserControls = new ObservableCollection<MyComboBoxItem>();
                }
                ActiveUserControls.Add(item);
            }
        }
    }
