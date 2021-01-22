    public class Base
    {
    	private string _id = "hi";
    	
    	public string Id { get { return _id; } }
    }
    
    public class Derived : Base
    {
    	public void changeParentVariable()
    	{
    		FieldInfo fld = typeof(Base).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(this, "sup");
    	}
    }
