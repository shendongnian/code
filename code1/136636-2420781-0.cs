    class Parent
    {
    	public static string MyField = "ParentField";
    	protected virtual MyLocalField = MyField;
    	
    	public virtual string DoSomething()
    	{
    		return MyLocalField;
    	}
    }
    class Child : Parent
    {
    	public static new string MyField = "ChildField";
    	protected override MyLocalField = MyField;
    }
