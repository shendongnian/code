    Console.WriteLine("Enter a sting ");
			var input = Console.ReadLine();
			Console.WriteLine("Here is all the possable combination ");
			foreach (var stringCombination in FindPermutationsSet(input))
			{
				Console.WriteLine(stringCombination);
			}
			Console.ReadLine();
 
