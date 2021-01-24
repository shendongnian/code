	class Program
	{
	    const int numberOfMarks = 5;
	    static void Main()
	    {
			List<int> marks = new List<int>();
			Enumerable.Range(1, numberOfMarks)
			.ForEach((i) => {
				Console.Write($"Enter element {i}:");
				marks.Add(int.TryParse(Console.ReadLine(), out var valueRead) ? valueRead : 0);
				Console.WriteLine($" {valueRead}");
			});
			Console.WriteLine(marks.Average() >= 0 ? "Positive" : "Negative");
		}
	}
