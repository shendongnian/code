    using System;
	using System.Linq;
	using System.Collections.Generic;
	
	public class Test
	{
		public static void Main()
		{
			// var allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
			var allowedChars = "0123456789.";
			
			Console.WriteLine(CheckInvalidInput("54323.5", allowedChars));   // True
			Console.WriteLine(CheckInvalidInput("543g23.5", allowedChars));  // False
		}
		
		private static bool CheckInvalidInput(string stringToCheck, IEnumerable<char> allowedChars)
		{
	    	return stringToCheck.All(allowedChars.Contains);
		}
	}
