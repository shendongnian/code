	public static void Main()
	{
		long N = long.Parse(Console.ReadLine());
		long c = 0;
		long N_squared = N * N;
		double half_N_squared = N_squared / 2.0 - 0.5;
		double x_limit = N - Math.Sqrt(2) / 2.0 * Math.Sqrt(N_squared + 1);
		for (long x = 2; x < x_limit; x += 2)
		{
			long x_squared = x * x + 1;
			double y_limit = (half_N_squared - N * x) / (N - x);
			for (long y = x; y < y_limit; y += 2)
			{
				long z_squared = x_squared + y * y;
				long digit = z_squared % 10;
				if (digit == 3 || digit == 7)
				{
					continue;  // minimalist non-perfect square elimination
				}
				long z = (long) Math.Sqrt(z_squared);
				if (z * z == z_squared)
				{
					c++;
				}
			}
		}
		Console.WriteLine(c);
	}
