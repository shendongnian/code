    int input;
    int[] count = new int[10];
		
	while (true)
	{
   		Console.WriteLine("Geben Sie bitte die {0,1}. Zahl ein (-1 für Ende): ");
    	input = Convert.ToInt32(Console.ReadLine());
		if(input >= 0 && input <= 9)
		{
			for (int x = 0; x < 10; ++x)
			{
				if(x == input)
				{
					count[x] += 1;
				}
			}
		}
    	else if (input == -1)
    	{
        	//Input finished, display of numbers appearances.          
        	for (int x = 0; x < 10; x++)
            	Console.WriteLine("Number " + x + " appears " + count[x] + " times");
			break;
    	}
    	else
    	{
        	break;
		}
	}
