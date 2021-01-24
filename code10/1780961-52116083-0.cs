	using System;
	using System.Text.RegularExpressions;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var inputString = "1 2 3";
			
            var values = Regex
                .Matches(inputString, @"(?<nr>\d+)")
                .OfType<Match>()
                .Select(m => m.Groups["nr"].Value)
                .ToArray();
			Console.WriteLine("Multipe numbers: " + (values.Length > 1 ? "yep" : "nope"));
			foreach (var v in values) 
			{
				Console.WriteLine(v);
			}
		}
	}
