    public class Foo
    {
         public bool DoSomething() { return false; }
    }
    
    public class Bar : Foo
    {
         public new bool DoSomething() { return true; }
    }
    
    public cass Test
    {
    	public static void Main ()
    	{
    		Foo test = new Bar ();
    		Console.WriteLine (test.DoSomething ());
    	}
    }
