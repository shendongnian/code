    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                
                // Create a new collection of 4 names.
                NameList n = new NameList();
                
                // Bind the grid to the list of names.
                dataGrid1.ItemsSource = n;
    
                // Get the first person by its row index.
                PersonName firstPerson = (PersonName) dataGrid1.Items.GetItemAt(0);
    
                // Access the columns using property names.
                Debug.WriteLine(firstPerson.FirstName);
    
            }
        }
    
        public class NameList : ObservableCollection<PersonName>
        {
            public NameList() : base()
            {
                Add(new PersonName("Willa", "Cather"));
                Add(new PersonName("Isak", "Dinesen"));
                Add(new PersonName("Victor", "Hugo"));
                Add(new PersonName("Jules", "Verne"));
            }
        }
    
        public class PersonName
        {
            private string firstName;
            private string lastName;
    
            public PersonName(string first, string last)
            {
                this.firstName = first;
                this.lastName = last;
            }
    
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
    
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
        }
    }
