    int ordinal = Example.Bar.Ordinal; // will be in range: [0, Count-1]
    string name = Example.Bas.Name; // "Bas"
    int count = Enumeration.Count<Example>(); // 3
    var value = Example.Foo.Value; // <-- Example.Const.Foo
    
    Example[] values;
    Enumeration.Values(out values);
    
    foreach (var value in Enumeration.Values<Example>())
    	Console.WriteLine(value); // "Foo", "Bar", "Bas"
    
    public int Switching(Example value)
    {
    	if (value == null)
    		return -1;
    	
        // since we are switching on a System.Enum tabbing to autocomplete all cases works!
    	switch (value.Value)
    	{
    		case Example.Const.Foo:
    			return 12345;
    		case Example.Const.Bar:
    			return value.GetHasCode();
    		case Example.Const.Bas:
    			return value.Ordinal * 42;
    		default:
    			return 0;
    	}
    }
