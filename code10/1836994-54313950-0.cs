	static void Main(string[] args)
	{
		List<Tuple<string, int>> PeopleStuckInThePond = new List<Tuple<string, int>>();
		Console.Write("Number of Test Cases? ");
		int input = Convert.ToInt32(Console.ReadLine());
		for(int i = 0; i <input; i++)
		{
			PeopleStuckInThePond.Clear();
			Console.WriteLine("Case " + (i + 1).ToString() + " of " + input.ToString());
			Console.Write("Number of Friends? ");
			int numberOfFrnd = Convert.ToInt32(Console.ReadLine());
			for (int j = 0; j < numberOfFrnd; j++)
			{
				Console.Write("Friend " + (j + 1).ToString() + " of " + numberOfFrnd.ToString() + ": ");
				var anotherInput = Console.ReadLine();
				var splitInput = anotherInput.Split(' ');
				var Fn = Convert.ToString(splitInput[0]);
				var time = Convert.ToInt32(splitInput[1]);
				PeopleStuckInThePond.Add(new Tuple<string, int>(Fn, time));
			}
			PeopleStuckInThePond.Sort((a, b) => b.Item2.CompareTo(a.Item2));
			Console.WriteLine("Answer: " + PeopleStuckInThePond.First().Item1 + " " + PeopleStuckInThePond.Last().Item1);
			Console.WriteLine("");
		}
		
		Console.Write("Press Enter to Quit");
		Console.ReadLine();
	}
