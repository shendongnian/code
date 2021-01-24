	int a, c;
	double b;
	a = Convert.ToInt32(Console.ReadLine());
	if (a < 100)
	{
		b = a + a * 0.2;
		Console.WriteLine(b);
	}
	else if (a > 200)
	{
		b = a + a * 0.3;
		Console.WriteLine(b);
	}
	else if (a == 300)
	{
		b = a + a * 0.4;
		Console.WriteLine(b);
	}
	else 
		Console.WriteLine(a);
