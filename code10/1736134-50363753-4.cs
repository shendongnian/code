    public static void Main()
    {
    	    double[] array = new double[5] {12.1, 5.9, 2.9, 6.8, 20.5};
    		
    		Console.WriteLine("Enter input:");              // Prompt for input
            string input = Console.ReadLine();       
    		
            int totalNums = Convert.ToInt32(input);
            //sort the array in descending order and get 
            //the desired number of elements out of it
    		var topNumbers = array.OrderByDescending(i => i) 
                        .Take(totalNums);
    		foreach (var x in topNumbers)
            {
                Console.WriteLine(x);
            }
    	}
