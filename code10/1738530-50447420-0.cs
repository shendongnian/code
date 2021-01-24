    public static void Main()
	{
		string input = "How are you today";
		var count = input.Split(' ').ToList().Count;
		var inp = input.Split(' ').ToList();
		
		
		for (int j = 0; j < count; j++)
		{ 	
			
	    	if(j % 2 == 1)
		   {
				
				Console.Write(inp[j].Reverse().ToArray());
	       }
			else
				Console.Write(" " + inp[j] + " ");
			
	  }
	}
