    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var lstIntOne = new List<int>() {1,2,3};
    		var lstIntTwo = new List<int>() {4,5,6};
    		var lstIntThree = new List<int>() {7,8,9};
    		
    		var lstOfLstInts = new List<List<int>>();
    		
    		lstOfLstInts.Add(lstIntOne);
    		lstOfLstInts.Add(lstIntTwo);
    		lstOfLstInts.Add(lstIntThree);
    		
    		var lstAllNumbers = lstOfLstInts.SelectMany(x => x).ToList();
    		
    		foreach(var item in lstAllNumbers)
    		{
    			Console.WriteLine(item);	
    		}
    	}
    }
    // Output
    // 1
    // 2
    // 3
    // 4
    // 5
    // 6
    // 7
    // 8
    // 9
