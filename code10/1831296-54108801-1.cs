    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChaged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private bool bool1;
        public bool Bool1
        {
            get { return bool1; }
            set { bool1 = value; RaisePropertyChaged("Bool1"); }
        }
        private bool bool2;
        public bool Bool2
        {
            get { return bool2; }
            set { bool2 = value; RaisePropertyChaged("Bool2"); }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
