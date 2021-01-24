	void Main()
	{
		var person = new Person("bob", "Smith", 27);
	
		var result = String.Join(Environment.NewLine, typeof(Person).GetFields().Select(p => $"{p.Name} {p.GetValue(person)}"));
		
		Console.WriteLine(result);
	}
	
	public class Person
	{
		public Person(string firstName, string lastName, int age)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.age = age;
		}
		public string firstName;
		public string lastName;
		public int age;
	}
	
