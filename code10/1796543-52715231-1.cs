    void Test()
    {
        var a = new MyClass();
        a.Name = "Test";
		var b = a;
		
		Console.WriteLine(a.Name); // "Test"
		Console.WriteLine(b.Name); // "Test"
		
		Mutate(ref a);
		Console.WriteLine(a.Name); // "John"
		Console.WriteLine(b.Name); // "Test"
	}
		
	void Mutate(ref MyClass myClass)
	{
		myClass = new MyClass();
		myClass.Name = "John";
	}
