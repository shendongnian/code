    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var charList = new List<char[]>();
    		
    		// Initialize list of char array
    		char[] array1 = { 's', 'a', 'm' };
    		char[] array2 = { 's', 'm', 'i', 't', 'h' };
    		char[] array3 = { 'c', 'o', 'o', 'l'};
    		
    		// Add them
    		charList.Add(array1);
    		charList.Add(array2);
    		charList.Add(array3);
    		
    		Console.WriteLine("--Before sorting--");
    		foreach (char[] item in charList) {
    			Console.WriteLine(item);
    		}
    		
    		// Sorting
    		charList = charList.OrderBy(a => new string(a)).ToList();
    		
    		
    		Console.WriteLine("--After sorting--");
    		foreach (char[] item in charList) {
    			Console.WriteLine(item);
    		}
    	}
    }
