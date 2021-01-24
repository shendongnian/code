    public partial class MainWindow : Window
    {
        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Start();
        }
        class VM : INotifyPropertyChanged
        {
            double dps1 = 2;
            double count;
            Timer timer;
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(nameof(Count));
            public VM()
            {
                timer = new Timer();
                timer.Interval = .0001;
                timer.Elapsed += (o, e) => Count = (count += dps1 / 2500);
            }
            public double Count
            {
                get
                {
                    return count;
                }
                set
                {
                    count = value;
                    PropertyChanged?.Invoke(this, args);
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void Start()
            {
                timer.Start();
            }
        }
    }
