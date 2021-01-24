    public partial class MainWindow : Window
    {
        List<DutyDay> tour = new List<DutyDay>(); // it is declared as global
        public MainWindow()
        {
            InitializeComponent();
    
            //List<DutyDay> tour = new List<DutyDay>(); It Is declared as local
            tour.Add(new DutyDay() { Day = "Day 1:" });
            tour.Add(new DutyDay() { Day = "Day 2:" });
            tour.Add(new DutyDay() { Day = "Day 3:" });
            tour.Add(new DutyDay() { Day = "Day 4:" });
            tour.Add(new DutyDay() { Day = "Day 5:" });
            tour.Add(new DutyDay() { Day = "Day 6:" });
    
            listBoxDutyDays.ItemsSource = tour;
        }
    
        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            foreach (DutyDay item in tour)  <-- "tour" is not recognized?!
            {
    
            }
        }
    }
