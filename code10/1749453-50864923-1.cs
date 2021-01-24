	static void Main(string[] args)
	{
		Person p1 = new Person();
		p1.Name = "Frank";
		p1.Age = 30;
		p1.Gender = "Male";
		p1.BirthDate = new DateTime(1986, 5, 12);
		Console.WriteLine(p1.Age);
		Console.ReadLine();
	}
