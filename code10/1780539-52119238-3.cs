    public partial class MainWindow : Window, INotifyPropertyChanged
    {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private string formatStringInVM = "Peer: {0}";
        public string FormatStringInVM
        {
            get { return formatStringInVM; }
            set
            {
                formatStringInVM = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FormatStringInVM)));
            }
        }
    
        private int someDatatInVM = 123;
        public int SomeDatatInVM
        {
            get { return someDatatInVM; }
            set
            {
                someDatatInVM = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeDatatInVM)));
            }
        }
    
        public MainWindow()
        {    
            this.DataContext = this;
            InitializeComponent();
        }
    
        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            SomeDatatInVM++;
        }
    
        private static int i = 1;
        private void Button_Click_1(Object sender, RoutedEventArgs e)
        {
            FormatStringInVM = "Peer-" + i.ToString() + ": {0}";
            i++;
        }
    }
