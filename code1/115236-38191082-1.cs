    Console.WriteLine("Enter a sting ");
    
    			var input = Console.ReadLine();
    
    			foreach (var stringCombination in FindPermutations(input))
    			{
    				Console.WriteLine(stringCombination);
    			}
    			Console.ReadLine();
