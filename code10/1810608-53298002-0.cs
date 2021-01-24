    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public DataTemplate DataTemplate
        {
            get {
                var myFactory = new FrameworkElementFactory(typeof(TextBlock));
                myFactory.SetBinding(TextBlock.TextProperty, new Binding(".")); //bind to the DataContext
                return new DataTemplate() { VisualTree = myFactory };
            }
        }
        private object _dctx = new object(); //set the Dxtc property somewhere
        public object Dctx
        {
            get { return _dctx; }
            set { _dctx = value; RaisePropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
