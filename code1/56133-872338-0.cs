    using System;
    
    class Program
    {
    	static void Main()
    	{
    		Foo foo = new Foo();
    	}
    }
    
    class Foo
    {
    	public Foo() : this("hello")
    	{
    		Console.WriteLine("world");
    	}
    
    	public Foo(String s)
    	{
    		Console.WriteLine(s);
    	}
    }
