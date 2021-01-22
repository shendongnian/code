       ObservableCollection<Person> People = new ObservableCollection<Person>();
       public Window1()
       {
           InitializeComponent();
           dataGrid1.ItemsSource = People;
       }
       private void AddNewRow_Click(object sender, RoutedEventArgs e)
       {
          People.Add(new Person() { FirstName = "Tom", LastName = "Smith", Age = 20 });
       }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
