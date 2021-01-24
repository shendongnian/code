    public partial class MainWindow : Window
    {
       public MainWindow()
       {
           InitializeComponent();
    
           DataContext = GetItems();
       }
    
       public List<Person> GetItems ()
       {
           return new List<Person>()
           {
               new Person {Name = "John", Surname = "Rocky", Cities = new List<string> { "New York City", "Washington D.C.", "Chicago" } },
               new Person {Name = "John", Surname = "Rocky"},
               new Person {Name = "John", Surname = "Rocky", Cities = new List<string> { "Baltimore", "San Francisco", "Boston" } }
           };
       }
    }
    
    public class Person
    {
       public string Name { get; set; }
       public string Surname { get; set; }
    
       public IEnumerable<string> Cities { get; set; }
       public string SelectedCity { get; set; }
    }
