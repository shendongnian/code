    public partial class MainWindow : Window
    {
        private Int32 i = 0;
        private ObservableCollection<string> components = new ObservableCollection<string>();
        public ObservableCollection<string> Components
        {
            get
            {
                if (components == null)
                    components = new ObservableCollection<string>();
                return components;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Components.Add("Part " + i.ToString());
            i += 1;
        }
    }
