    public partial class MainWindow : Window
    {
        private StatusOfWork _StatusOfWork;
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public string LapsedTime 
        {
            get { return (string) GetValue(LapsedTimeProperty); }
            set { SetValue(LapsedTimeProperty, value); }
        }
    
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartDateTime = DateTime.Now;
            for(int count = 0; count < 10; count ++)
            {
                LapsedTime = string.Format("{0}", count);
                Thread.Sleep(1000);
            }
            this.Close();
        }
    }
