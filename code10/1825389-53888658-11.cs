    public partial class MainWindow : Window
    {
        private StatusOfWork _StatusOfWork;
    
        public MainWindow()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ElapsedTimeProperty =
            DependencyProperty.Register(nameof(ElapsedTime), typeof(string), typeof(MainWindow));
    
        public string ElapsedTime
        {
            get { return (string)GetValue(ElapsedTimeProperty); }
            set { SetValue(ElapsedTimeProperty, value); }
        }
    
        private async void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            
            for(int count = 0; count < 10; count ++)
            {
                ElapsedTime = string.Format("{0}", count);
                await Task.Delay(1000);
            }
            this.Close();
        }
    }
