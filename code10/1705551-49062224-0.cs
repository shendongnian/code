    Console.Write("Enter the number of tests: ");
    int n = int.Parse(Console.ReadLine());
    int[] scores = new int[n];
    
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Please enter the test scores");
    
    for (int i = 0; i < n; i++)
    {
    	int input = -1;
    	do
    	{
    		input = Convert.ToInt32(Console.ReadLine());
    		if (input < 0)
    		{
    			Console.WriteLine("Please enter a value greater than 0");    
    		}    
    		else if (input > 100)
    		{
    			Console.WriteLine("Please enter a value less than 100");    
    		}
    	} while (input < 0 || input > 100);
    
    	scores[i] = input;
    }
    
    int sum = 0;
    foreach (int d in scores)
    {
    	sum += d;
    }
    
    Console.WriteLine("The sum of all the scores is {0}", sum);
    Console.ReadLine();
