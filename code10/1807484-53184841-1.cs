    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Test> tests { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            tests = new ObservableCollection<Test>();
            for (int i=0;i<100;i++)
            {
                tests.Add(new Test() {Username="name "+i });
            }
            StudentListView.ItemsSource = tests;
        }
        private void finishBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudents = tests.Where(x => x.IsSelected == true).ToList();
        }
    }
