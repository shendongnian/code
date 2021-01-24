    public partial class MainWindow : Window
    {
        public MainWindow()
        {
              Persons = new List<Persons>();
              Persons.Add(new Person("Name1"));
              Persons[0].Childs = new List<Person>();
              Persons[0].Childs[0].Add(new Person("Child1"));
              InitializeComponent();
            
        }
        public List<Person> Persons{ get; private set; }
    }
