    using System;
    using System.Reflection;
	class Constants
	{
		public const string MIN_NAME_LENGTH = "10";
		public const string MAX_NAME_LENGTH = "20";
		
		public static string GetValue(string index)
		{
    		return typeof(Constants)
	    		.GetField(index, BindingFlags.Public | BindingFlags.Static)
		    	.GetValue(null) as string;
		}
	}
						
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine(Constants.GetValue("MIN_NAME_LENGTH"));
			Console.WriteLine(Constants.GetValue("MAX_NAME_LENGTH"));
		}
	}
