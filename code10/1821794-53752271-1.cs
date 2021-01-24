    var numbers = new HashSet<int>();	
    	while(numbers.Count < 5)
    	{
    		 Console.WriteLine("Enter a number:"); //1.
    		 var number = Convert.ToInt32(Console.ReadLine());
    		 
    		if (numbers.Contains(number)) // 2.
    		{
    			 Console.WriteLine("exists\n"); //3.
    			 continue;
    		}
    		
    		Console.WriteLine("new\n"); //4.
    		numbers.Add(number);
    	}
    	
    	foreach (var n in numbers)
    	{
    		Console.WriteLine(n);
    	}
