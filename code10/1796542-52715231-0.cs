    public class MyClass
    {
        public string Name {get;set;}
    }
    void Test()
    {
        var a = new MyClass();
        a.Name = "Test";
		var b = a;
		
		Console.WriteLine(a.Name); // "Test"
		Console.WriteLine(b.Name); // "Test"
		
		b.Name = "MossTeMuerA";
		Console.WriteLine(a.Name); // "MossTeMuerA"
		Console.WriteLine(b.Name); // "MossTeMuerA"
		
		Mutate(a);
		Console.WriteLine(a.Name); // "John"
		Console.WriteLine(b.Name); // "John"
	}
	
	void Mutate(MyClass myClass)
	{
		myClass.Name = "John";
	}
