	void Main()
	{
		var x = new { a=5, b="hi" };
		MakeDictionary(x).Dump();
	}
	
	// helper function to create the dictionary from the anonymous tyle
	static public IDictionary MakeDictionary(object o)
	{
		Type type = o.GetType();
		return type.GetProperties()
		.Select(n => n.Name)
		.ToDictionary(k => k, k => type.GetProperty(k).GetValue(o, null));
	}
