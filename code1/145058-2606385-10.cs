    public static void Main(string[] args)
    {
    	using (var tester = new NamespaceTester())
    	{
    		var success = tester.Test(new[] {
    			"System.IO",
    			"System.LOL"
    		});
    	}
    }
