    void Main()
    {
    	DoSomething(new MyClass { a = 5 });
    	DoSomething(new List<MyClass> { new MyClass { a = 5 }, new MyClass { a = 5 }});
    }
    
    
    public void DoSomething(object t)
    {
    	switch (t)
    	{
    		case MyClass c:
    			Console.WriteLine($"class.a = {c.a}");
    			break;
    		case List<MyClass> l:
    			Console.WriteLine($"list.count = {l.Count}");
    			break;
    	}
    }
    
    class MyClass
    {
    	public int a { get; set;}
    }
