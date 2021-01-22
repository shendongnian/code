    public class MyList<T> : List<T>
    {
    	public void Add( params object[] arguments )
    	{
    		// what order should I bind the values to?
    	}
    }
    var childObjects = new MyList<ChildObject>
    {
    	{ "Sylvester", 8 } , { "Whiskers", 2 }, { "Sasha", 14 }
    };
