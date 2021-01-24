    public class MyAttrAttribute : Attribute
    {
    	public string[] AllowedValues { get; }
    	public MyAttrAttribute(params string[] values)
    	{
    		AllowedValues = values;
    	}
    }
