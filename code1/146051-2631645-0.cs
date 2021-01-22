    static void Main(string[] args)
    {
    	Test(null, "", "", "");
    }
    
    static void Test(MyClass arg1, params string[] args)
    {
    	if (args.Count(a => String.IsNullOrEmpty(a)) == args.Length)
    	{
    		throw new Exception("All params are null or empty");
    	}
    }
