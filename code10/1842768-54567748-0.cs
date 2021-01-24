    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseDown += Window3_PreviewMouseDown;
            PreviewMouseUp += Window3_PreviewMouseUp;
        }
    
        DateTime mouseDown;
        private void Window3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseDown = DateTime.Now;
        }
    
        private void Window3_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            timerMinute = DateTime.Now.Subtract( mouseDown );
            minuteTimerLabel.Content = String.Format( "{0:00}", timerMinute );
        }
    }
