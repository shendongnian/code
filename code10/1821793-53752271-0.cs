    var numbers = new HashSet<int>();	
    	while(numbers.Count < 5)
    	{
    		 Console.WriteLine("Enter a number:");
    		 var number = Convert.ToInt32(Console.ReadLine());
    		 
    		if (numbers.Contains(number))
    		{
    			 Console.WriteLine("exists\n");
    			 continue;
    		}
    		
    		Console.WriteLine("new\n");
    		numbers.Add(number);
    	}
    	
    	foreach (var n in numbers)
    	{
    		Console.WriteLine(n);
    	}
