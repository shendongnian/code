    double[] arr = { 2.1, 70.1, 15.1, 92.1, 105.1, 65.1, 40.1, 9.1, 22.1 };		
    int n = 3;
    	List<double> list = new List<double>(arr);
		Console.WriteLine("Top {0} elements", n);
    	for(int i = 0; i < n; i++)
    	{
    	  double max = list.Max();	
    	  Console.WriteLine(max);
    		list.Remove(max);
    	}
    Output:Top 3 elements
    105.1
    92.1
    70.1
