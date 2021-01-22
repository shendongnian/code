    class Program
    {
    	static void Main()
    	{
    		int foo = 0;
    		DoSomething1(foo);
    		Console.WriteLine(foo); // Outputs 0.
    		
    		DoSomething1(ref foo);
    		Console.WriteLine(foo); // Outputs 1.
    		
    		var bar = new List<int>();
    		DoSomething2(bar);
    		Console.WriteLine(bar.Count); // Outputs 1.
    		
    		DoSomething2(ref bar);
    		Console.WriteLine(bar.Count); // Outputs 0.
    	}
    	
    	// Pass by value.
    	static void DoSomething1(int number)
    	{
    		// Can't modify the number!
    		number++;
    	}
    	
    	// Pass by value.
    	static void DoSomething1(ref int number)
    	{
    		// Can modify the number!
    		number++;
    	}
    	
    	// Pass reference by value.
    	static void DoSomething2(List<int> list)
    	{
    		// Can't change the reference, but can mutate the object.
    		list.Add(25);
    	}
    	
    	// Pass reference by reference.
    	static void DoSomething2(ref List<int> list)
    	{
    		// Can change the reference (and mutate the object).
    		list = new List<int>();
    	}
    }
