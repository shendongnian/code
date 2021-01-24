    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var listOfList = new List<List<double>>();
    		
    		for (var i = 0; i < 4; i++)
    		{
    			listOfList.Add(new List<double>(5));
    		}
    		
    		foreach (var item in listOfList)
    		{
    			item.AddRange(GetList(5));
    		}
    		
    		for(var i = 0; i < listOfList.Count; i++)
    		{
    			for (var j = 0; j < listOfList[i].Count; j++)
    			{
    				Console.WriteLine($"listOfList[{i}][{j}] = {listOfList[i][j]}");
    			}
    		}
    	}
    	
    	private static IList<double> GetList(int maxCapacity)
    	{
    		var newList = new List<double>(maxCapacity);
    		
    		for (var i = 0; i < maxCapacity; i++)
    		{
    			newList.Add(i);
    		}
    		
    		return newList;
    	}
    }
