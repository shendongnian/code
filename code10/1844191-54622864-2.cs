	void Main()
	{
		var person = new Person("bob", "Smith", 27);
	
		var result = person.ToString();
	
		Console.WriteLine(result);
	}
	
	public class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
	
		public Person(string firstName, string lastName, int age)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
		}
	
		public override string ToString()
		{
			return String.Format("FirstName {0}\nLastName {1}\nAge {2}", FirstName, LastName, Age);
		}
	}
	
