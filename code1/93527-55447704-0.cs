    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;    // this row fixed everything
        }
        ****
        Some code here with properties etc
        ***
    }
