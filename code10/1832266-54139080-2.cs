	{
		int a = 5;
		{
			a = 3;
		}
		{
			Console.WriteLine(a); // this will also work because a is declared outside the scope. Its value is 3.
		}
	}
