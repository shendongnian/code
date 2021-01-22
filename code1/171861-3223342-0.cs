	class Test
	{
		static int buyIn; 
		static int numChips;
		static List<int> chips = new List<int>(); // chips[i] = value of chips of color i
		static List<int> amountOfChips = new List<int>(); // amountOfChips[i] = number of chips of color i
		static void generateSolutions(int sum, int[] solutions, int last)
		{
			if (sum > buyIn) // our sum is too big, return
				return;
			if (sum == buyIn) // our sum is just right, print the solution
			{
				for (int i = 0; i < chips.Count; ++i)
					Console.Write("{0}/", solutions[i]);
				Console.WriteLine();
				return; // and return
			}
			for (int i = last; i < chips.Count; ++i) // try adding another chip with the same value as the one added at the last step. 
				                                     // this ensures that no duplicate solutions will be generated, since we impose an order of generation
				if (amountOfChips[i] != 0)
				{
					--amountOfChips[i]; // decrease the amount of chips
					++solutions[i]; // increase the number of times chip i has been used
					generateSolutions(sum + chips[i], solutions, i); // recursive call
					++amountOfChips[i]; // (one of) chip i is no longer used
					--solutions[i]; // so it's no longer part of the solution either
				}
		}
		static void Main()
		{
			Console.WriteLine("Enter the buyin:");
			buyIn = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the number of chips types:");
			numChips = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter {0} chips values:", numChips);
			for (int i = 0; i < numChips; ++i)
				chips.Add(int.Parse(Console.ReadLine()));
			Console.WriteLine("Enter {0} chips amounts:", numChips);
			for (int i = 0; i < numChips; ++i)
				amountOfChips.Add(int.Parse(Console.ReadLine()));
			int[] solutions = new int[numChips];
			generateSolutions(0, solutions, 0);
		}
	} 
