	public static void TestStack()
	{
		ConcurrentStack<int> numbers = new ConcurrentStack<int>();
		for (int i = 10; i > 0; i--)
		{
			numbers.Push(i);
		}
		Random random = new Random();
		for (int i = 0; i < 8; i++)
		{                
			Task.Run(() => { ConsumeStack(numbers, random); });
		}
		Task.WaitAll();
		PrintStack(numbers);
	}
	private static void ConsumeStack(ConcurrentStack<int> numbers, Random random)
	{
		if (numbers.Any())
		{
			int number = 0;
			if (numbers.TryPop(out number))
			{
				Console.WriteLine("Popped {0}.", number);
				var delay = random.Next(1, 500);
				Thread.Sleep(delay);
				numbers.Push(number);
				Console.WriteLine("Pushed {0}.", number);
			}                    
			else
				Console.WriteLine("Failed to pop.");                
		}
		PrintStack(numbers);
	}
	private static void PrintStack(ConcurrentStack<int> stack)
	{
		Console.WriteLine("Stack" + string.Join(",", stack.Select(s => s.ToString())));
	}
