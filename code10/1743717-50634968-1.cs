    public partial class MainWindow : Window
    {
        ObservableCollection<CustomDate> CallNameList = new ObservableCollection<CustomDate>();
        public MainWindow()
        {
            InitializeComponent();
            CallNameList.Add(new CustomDate("Date #1", "Description of first date"));
            CallNameList.Add(new CustomDate("Date #2", "This is a fantastic date"));
            CallNameList.Add(new CustomDate("Date #3", "It will rain today"));
            MyList.DataContext = CallNameList;
        }
        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            CallNameList.Remove((CustomDate)MyList.SelectedItem);
        }
    }
