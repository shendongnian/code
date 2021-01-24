    if (true)
    {
		int n = 4;
		int i, j, k = 0;
		for (i = 1; i <= n; i++)
		{
			for (j = i; j < n; j++)
			{
				Console.Write(" ");
			}
			while (k != (2 * i - 1))
			{
				if (k == 0) 	Console.Write("          "); //Added
				if (k == 0 || k == 2 * i - 2)
					Console.Write("*");
				else
					Console.Write(" ");
				k++;
			}
			k = 0;
			Console.WriteLine();
		}
		Console.Write("          ");  //Added
		for (i = 0; i < 2 * n - 1; i++)
		{
			Console.Write("*");
		}
		
       Console.WriteLine();
    }
