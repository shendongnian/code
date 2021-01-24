    public partial class MainWindow : Window,  INotifyPropertyChanged
    {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public ObservableCollection<PositionTab> PositionTabs { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
            PositionTabs = new ObservableCollection<PositionTab>();
            RaisePropertyChanged("PositionTabs");
            for (int i = 0; i <= 4; i++)
            {
                PositionTabs.Add(new PositionTab(i));
            }
    
        }
    }
