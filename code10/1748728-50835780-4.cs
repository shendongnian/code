    public static string ProcessThings(Ibar item)
    {
    	var theType = item.GetType();
    	Console.WriteLine(theType.Name);
    	MethodInfo method = typeof(Program).GetMethods()
    		.Where(x => x.IsStatic && x.Name == "DoSomething" && x.ToString().Contains(theType.Name))
    		.SingleOrDefault();
    
    	var ret = method.Invoke(null, new object[] { item });
    
    	return ret?.ToString();
    }
    public static string DoSomething(barX item)
    {
    	return "foo";
    }
    
    public static string DoSomething(bar2 item)
    {
    	return "bar";
    }
