    public class MyClass
    {
    	private interface IFoo
    	{
    		int MyProp { get; }
    	}
    	
    	private class Foo : IFoo
    	{
    		public int MyProp { get; set; }
    	}
    	
    	public static void Main	(string[] args)
            {
    		IFoo foo = new Foo();
    		return foo.MyProp;
    	}
    }
