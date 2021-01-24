     public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private ObservableCollection<string> _labels = new ObservableCollection<string>();
        public ObservableCollection<string> LabelItems
        {
            get { return _labels; }
            set { _labels = value; RaisePropertyChanged(); }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Input.Text != "" && Input.Text != null)
            {
                LabelItems.Add(Input.Text);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
