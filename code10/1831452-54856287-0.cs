	public static void Main()
	{
		int N = 10000;
		int c = 0;
		int N_squared = N * N;
		double half_N_squared = N_squared / 2.0 - 0.5;
		double x_limit = N - Math.Sqrt(2) / 2.0 * Math.Sqrt(N_squared + 1);
		for (int x = 2; x < x_limit; x += 2)
		{
			int x_squared = x * x + 1;
			double y_limit = (half_N_squared - N * x) / (N - x);
			for (int y = x; y < y_limit; y += 2)
			{
				int z_squared = x_squared + y * y;
				int digit = z_squared % 10;
				if (digit == 3 || digit == 7)
				{
					continue;  // minimalist non-perfect square elimination
				}
				int z = (int) Math.Sqrt(z_squared);
				if (z * z == z_squared)
				{
					c++;
				}
			}
		}
		Console.WriteLine(c);
	}
