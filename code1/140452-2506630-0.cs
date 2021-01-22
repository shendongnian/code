	class Program
	{
		static void Main(string[] args)
		{
			int n = 100000;
			if (args[0] == "1")
				WithIntern(n);
			else
				WithoutIntern(n);
		}
		static void WithIntern(int n)
		{
			var list = new List<string>(n);
			for (int i = 0; i < n; i++)
			{
				for (int k = 0; k < 10; k++)
				{
					list.Add(string.Intern(new string('x', k * 1000)));
				}
			}
			GC.Collect();
			Console.WriteLine("Done.");
			Console.ReadLine();
		}
		static void WithoutIntern(int n)
		{
			var list = new List<string>(n);
			for (int i = 0; i < n; i++)
			{
				for (int k = 0; k < 10; k++)
				{
					list.Add(new string('x', k * 1000));
				}
			}
			GC.Collect();
			Console.WriteLine("Done.");
			Console.ReadLine();
		}
	}
