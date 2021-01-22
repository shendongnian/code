    int[] ia = new int[] { -4, 10, 11, 12, 13, -1, 9, 8, 7, 6, 5, 4, -2, 
                            6, 15, 32, -5, 6, 19, 22 };
    
    // Call the Extension method
    int[] results = ia.SelectRangeLoop(-2);
    
    // Print Results
    for (int i = 0; i < results.Length; i++)
    {
    	Console.Write(" {0} ", results[i]);
    }
