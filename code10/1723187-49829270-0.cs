    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyList = new ObservableCollection<Playlists>();
            MyListBox.ItemsSource = MyList;
        }
        private ObservableCollection<Playlists> MyList { get; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyList.Add(new Playlists(DateTime.Now.ToShortTimeString()));
        }
    }
    public class Playlists
    {
        public Playlists(string title) { Title = title; }
        public string Title { get; }
        public override string ToString() { return Title; }
    }
