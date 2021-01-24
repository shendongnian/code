    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Items  = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
            Items.Add(new Person(){FirstName = "James", LastName = "Tays"});
            
            this.DataGrid.ItemsSource = Items;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.DataGrid.Columns.Any())
            {
                var binding = new Binding("LastName");
                this.DataGrid.Columns.Add(new DataGridTextColumn(){Header = "Last Name", Binding = binding});
            }
            else
            {
                var binding = new Binding("FirstName");
                this.DataGrid.Columns.Add(new DataGridTextColumn(){Header = "FirstName", Binding = binding});
            }
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    }
