    public static void Main()
    {
    	    double[] array = new double[7] { 1.7, 3.12, 5.65, 2.2, 82.65, 6.09, 4.34 };
    		
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
