	class Program
	{
		const int numberOfMarks = 5;
		static void Main()
		{
			double average = 0;
			int[] marks = new int[numberOfMarks];
	
			for (int a = 0; a < numberOfMarks; a++)
			{
				Console.WriteLine("Enter 5 elements:");
				string line = Console.ReadLine();
				Console.WriteLine(line);
				
				marks[a] = int.Parse(line);
	
			}
			for (int i = 0; i < marks.Length; i++)
			{
				average = marks.Average();
			}
			if (average > 0)
			{
				Console.WriteLine("Positive");
			}
			else
			{
				Console.WriteLine("Negative");
			}
		}
	}
