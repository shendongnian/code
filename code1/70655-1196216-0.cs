    public partial class Window2 : Window
	{
		private List<Person> _persons = new List<Person>();
		public Window2()
		{
			InitializeComponent();
			_persons.Add(new Person("Joe"));
			_persons.Add(new Person("Fred"));
			_persons.Add(new Person("Jim"));
		}
		public List<Person> Persons
		{
			get { return _persons; }
		}
		public static List<Person> FilterList
		{
			get
			{
				return new List<Person>()
				{
					new Person("Joe"), 
					new Person("Jim")
				};
			}
		}
	}
	public class Person
	{
		string _name;
		public Person(string name)
		{
			_name = name;
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public override string ToString()
		{
			return _name;
		}
	}	
