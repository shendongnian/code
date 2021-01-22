    class Foo
    {
    	public string Bar
    	{
    		get;
    		set;
    	}
    	
    	public void Baz()
    	{
    		Console.WriteLine(Bar);
    	}
    }
    
    Foo foo = new Foo();
    Action someDelegate = foo.Baz;
    
    // Produces "Hello, world".
    foo.Bar = "Hello, world";
    someDelegate();
