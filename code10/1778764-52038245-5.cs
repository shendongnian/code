    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Persons = new ObservableCollection<Person>();
            Persons.Add(new Person("Name1"));
            Persons[0].Childs = new ObservableCollection<Person>();
            Persons[0].Childs.Add(new Person("Child1"));
            Persons[0].Childs.Add(new Person("Child2"));
            Persons[0].Childs[0].Childs = new ObservableCollection<Person>();
            Persons[0].Childs[0].Childs.Add(new Person("Child1 Child2"));
            InitializeComponent();
            this.DataContext = this;
        }
        public ObservableCollection<Person> Persons { get; private set; }
    }
