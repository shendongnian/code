    void Test()
    {
		MyClass a;
		Instantiate(out a);
		Console.WriteLine(a.Name); // "John"
	}
		
	void Instantiate(out MyClass myClass)
	{
		myClass = new MyClass();
		myClass.Name = "John";
	}
