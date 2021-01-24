    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<CountryData> orderDataGridItems;
        public List<CountryData> OrderDataGridItems
        {
            get { return orderDataGridItems; }
            set
            {
                orderDataGridItems = value;
                OnPropertyChanged("OrderDataGridItems");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            var listFromDataBase = new List<CountryData>();
            listFromDataBase.Add(new CountryData { CountryName ="India"});
            OrderDataGridItems = listFromDataBase;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
     }
