    public (string Name, int Age) GetPerson()
	{
		return (Name: "John", Age: 30);
	}
	
    var john = GetPerson();
	Console.WriteLine(john.Age); // 30
	
