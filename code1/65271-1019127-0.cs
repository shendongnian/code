    using System;
    
    class Program
    {
    	static void Main()
    	{
    		Foo foo = new Foo();
    		foo.Fooing += () => Console.WriteLine("Foo foo'd");
    
    		foo.PleaseRaiseFoo();
    	}
    }
    
    class Foo
    {
    	public event Action Fooing;
    
    	protected void OnFooing()
    	{
    		if (this.Fooing != null)
    			this.Fooing();
    	}
    
    	public void PleaseRaiseFoo()
    	{
    		this.OnFooing();
    	}
    }
