    public partial class MainWindow: Window
    {
        List<DutyDay> tour = new List<DutyDay>();
    
        public MainWindow()
        {
            InitializeComponent();
            //Your other stuff here.
        }
    
        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            foreach (DutyDay item in tour)  <-- Now its recognized
            {
    
            }
        }
    }
