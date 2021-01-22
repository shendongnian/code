    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		List<int> list = new List<int> { 1, 2, 3 };
    
    		Predicate<int> predicate = new Predicate<int>(greaterThanTwo);
    
    		List<int> newList = list.FindAll(predicate);
    	}
    
    	static bool greaterThanTwo(int arg)
    	{
    		return arg > 2;
    	}
    }
