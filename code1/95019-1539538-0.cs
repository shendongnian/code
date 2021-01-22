    public class MyListOfChildObjects : List<ChildObject>
    {
    	public void Add( string name, int age )
    	{
    		Add ( new ChildObject { Name = name, Age = age } );
    	}
    }
    var childObjects = new MyListOfChildObjects 
    {
    	{ "Sylvester", 8 } , { "Whiskers", 2 }, { "Sasha", 14 }
    };
