    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    	
    public class Program
    {
    	private static Random random = new Random();
    	private static Regex fileNameFragmentPattern = new Regex(@"\[(.*?)\]\.xlsx");
    	private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    	
    	public static void Main()
    	{
    		var fileNames = new List<string>();
    		
    		// Generate random file names 
    		for (var i = 0; i < 10000; i++) {
    			fileNames.Add(RandomString(random.Next(8,10)) +  "_" + RandomString(random.Next(4,5)) + "_"  + "(TEXT) [" + RandomDate().ToString("MM-dd-yyyy") + "].xlsx");
    		}
    		
    		// sort files by parsed dates
    		var dateSortedFileNames = fileNames.OrderByDescending( f => ExtractDate(f));
    		foreach (var fileName in dateSortedFileNames) {
    			// you can do anything with sorted files here (or anywhere else below :)
    			Console.WriteLine(fileName);
    		}		
    	}
    	
    	public static DateTime ExtractDate(string fileName) {
    		var fragment = fileNameFragmentPattern.Match(fileName).Value;
    		var month = int.Parse(fragment.Substring(1,2));
    		var day = int.Parse(fragment.Substring(4,2));
    		var year = int.Parse(fragment.Substring(7,4));
    		return new DateTime(year, month, day);		
    	}
    	
    	public static string RandomString(int length)
    	{
    		return new string(Enumerable.Repeat(chars, length)
    		  .Select(s => s[random.Next(s.Length)]).ToArray());
    	}
    	
    	public static DateTime RandomDate(int min = -9999, int max = 9999)
    	{
    		return DateTime.Now.AddDays(random.Next(min,max));
    	}
    }
