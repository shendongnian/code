    int[] myArray = new int[] { 0, 1, 2, 3, 13, 8, 5 };
    int largest = 0;
    int second = 0;
    foreach (int i in myArray)
    {
    	if (i > largest)
    	{
    		second = largest;
    		largest = i;
    	}
    	else if (i > second)
    		second = i;
    }
    
    System.Console.WriteLine(second);
