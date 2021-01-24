    public static void Main()
    {
    		int[] array = new int[7] { 1, 3, 5, 2, 8, 6, 4 };
    		
    		Console.WriteLine("Enter input:");              // Prompt for input
            string input = Console.ReadLine();       
    		
            int highestNums = Convert.ToInt32(input);
    		var topNumbers = array.OrderByDescending(i => i)
                        .Take(highestNums);
    		foreach (var x in topNumbers)
            {
                Console.WriteLine(x);
            }
    	}
