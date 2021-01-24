    	int numberOfElements = Convert.ToInt32(Console.ReadLine());   
		
		int sum= 0;
		for (int i=0; i< numberOfElements; i++)
	    {
 
			string input = Console.ReadLine();     
			sum += Array.ConvertAll(input.Split(' '), int.Parse).Sum();
		}
		
		Console.WriteLine(sum);
