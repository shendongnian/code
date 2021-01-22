    public static void Main()
    {
    	//set up the expected range
    	var expectedRange = Enumerable.Range(0, 10);
    	
    	//set up the current list
    	var currentList = new List<int> {1, 2, 4, 7, 9};
    	
    	//get the missing items
    	var missingItems = expectedRange.Except(currentList);		
    		
    	//print the missing items
    	foreach (int missingItem in missingItems)
    	{
    		Console.WriteLine(missingItem);
    	}
    	
    	Console.ReadLine();
    }
