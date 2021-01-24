    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent();
            Nose.DataContext = this;
        }
        public decimal? Text { get; set; }
    }
