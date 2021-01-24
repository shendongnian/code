    public partial class MainWindow : Window
    {
        Reservations reservations;
        public MainWindow()
        {
            InitializeComponent();
            reservations = new Reservations();
            dataGridReservations.ItemsSource = reservations.List;
        }
        public class Reservations
        {
            public class Reservation
            {
                private string _movieName;
                private string _seat;
                private string _rowID;
                public Reservation(string movieName, string seat, string rowID)
                {
                    MovieName = movieName;
                    Seat = seat;
                    RowID = rowID;
                }
                public string MovieName { get => _movieName; set => _movieName = value; }
                public string Seat { get => _seat; set => _seat = value; }
                public string RowID { get => _rowID; set => _rowID = value; }
            }
            private ObservableCollection<Reservation> _list;
            public ObservableCollection<Reservation> List { get => _list; set => _list = value; }
            public Reservations()
            {
                List = new ObservableCollection<Reservation>();
            }
            public void AddReservationToList(string MovieName, string SeatNumber, string RowId)
            {
                Reservation reservation = new Reservation(MovieName, SeatNumber, RowId);
                List.Add(reservation);
            }
        }
        private void ButtonAddReservationToList(object sender, RoutedEventArgs e)
        {
            reservations.AddReservationToList(textBoxMovieName.Text, textBoxSeatNumber.Text, textBoxRowId.Text);
            textBoxMovieName.Text = "";
            textBoxSeatNumber.Text = "";
            textBoxRowId.Text = "";
        }
    }
