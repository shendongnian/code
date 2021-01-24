    public static void Main()
    {
    	List<string> ListTest = new List<string>();
    	ListTest.Add("01293821921DE is refunded successfully");
    	ListTest.Add("0123821921DE is refunded successfully");
    	ListTest.Add("01693821921DE is refunded successfully");
    	
    	Console.WriteLine("\n List in Order \n");
    	
    	foreach(var item in ListTest)
    	{
    		Console.WriteLine(item);
    	}
    	
    	Console.WriteLine("\n List in Reverse Order \n");
    	
    	for(int i = ListTest.Count() - 1; i >= 0; i--)
    	{
    		Console.WriteLine(ListTest[i]);
    	}
    }
