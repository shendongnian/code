    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _cmPaymentDate;
        public DateTime CmPaymentDate
        {
            get
            {
                return _cmPaymentDate;
            }
            set
            {
                _cmPaymentDate = value;
                OnPropertyChanged("CmPaymentDate");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CmPaymentDate = new DateTime(2018, 09, 23);
        }
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
