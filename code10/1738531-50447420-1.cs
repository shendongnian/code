    public static void Main()
	{
		string input = "How are you today";
		var inp = input.Split(' ').ToList();
		for (int j = 0; j < inp.Count(); j++)
		{ 	
	       if(j % 2 == 1)
		   {
			   Console.Write(inp[j].Reverse().ToArray());
	       }
		   else
			   Console.Write(" " + inp[j] + " ");
	    }
	}
