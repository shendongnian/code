	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var numbers = new List<short>{ 1, 3, 10, 1, 2, 44, 26};
			var channel1 = numbers
				.Where((n, i) => i % 2 == 0)
				.SelectMany(n => new List<short> { n, n })
				.ToList();
			var channel0 = numbers
				.Where((n, i) => i % 2 == 1)
				.SelectMany(n => new List<short> { n, n })
				.ToList();
			Console.WriteLine(string.Join(",", channel0.Select(s => s.ToString())));
			Console.WriteLine(string.Join(",", channel1.Select(s => s.ToString())));
		}
	}
