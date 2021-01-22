    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }
    
        private DispatcherTimer dispatcherTimer;
    
        private int counter;
        public int Counter
        {
            get { return counter; }
            set
            {
                counter = value;
                OnPropertyChanged("Counter");
            }
        }
    
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Counter++;
            if (Counter == 5)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler e = PropertyChanged;
            if (e != null)
            {
                e(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
