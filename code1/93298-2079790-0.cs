    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = Enumerable.Range(0, 50).Select(x => new Person()
            {
                FirstName = "John",
                LastName = "Smith",
                ID = x,
                Delinquent = (x % 5 == 0)     // every fifth person is 'delinquent'
            });
        }
        private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var person = (Person)e.Row.DataContext;
            if (person.Delinquent)
            {
                e.Row.Background = new SolidColorBrush(Colors.Red);
                e.Row.Foreground = new SolidColorBrush(Colors.White);
                e.Row.FontStyle = FontStyles.Italic;
            }
            else
            {
               // defaults - without these you'll get randomly colored rows
               // e.Row.Background = new SolidColorBrush(Colors.Green);
               // e.Row.Foreground = new SolidColorBrush(Colors.Black);
               // e.Row.FontStyle = FontStyles.Normal;
            }
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public bool Delinquent { get; set; }
        }
    }
