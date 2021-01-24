    using System;
    using System.Collections.Generic;
    namespace LanguageNumberConverter
    {
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter a number: ");
			var input = int.Parse(Console.ReadLine());
			var result = NumberConverter(input);
			Console.WriteLine($"The number {input} = {result}.");
		}
		static string NumberConverter(int number)
		{
			var resultWords = new List<string>();
			var chars = number.ToString().ToCharArray();
			var largeCount = (chars.Length - 1) / 3;
			for (var l = largeCount; l >= 0; l--)
			{
				
				var searchRange = chars.Length - (l * 3);
				var digitStart = searchRange - 3 > 0 ? searchRange - 3 : 0;
				var digitsInLarge = l == largeCount ? chars.Length % 3 : 3;
				var teenFound = false;
				//Hundreds
				if (digitsInLarge > 2)
				{
					var hunDigit = int.Parse(chars[digitStart].ToString());
					resultWords.Add(Ones[hunDigit]);
					resultWords.Add("Hundred");
				}
				//Tens
				if (digitsInLarge > 1)
				{
					var tenDigit = int.Parse(chars[digitStart + digitsInLarge - 2].ToString());
					if (tenDigit == 1)
					{
						teenFound = true;
						var teenDigit = (tenDigit * 10) + int.Parse(chars[digitStart + digitsInLarge - 1].ToString());
						resultWords.Add(Ones[teenDigit]);
					}
					else
					{
						resultWords.Add(Tens[tenDigit]);
					}
				}
				//Ones
				if (!teenFound)
				{
					var oneDigit = int.Parse(chars[digitStart + digitsInLarge - 1].ToString());
					resultWords.Add(Ones[oneDigit]);
				}
				//Large
				if (l > 0)
				{
					var unit = Large[l];
					resultWords.Add(unit);
				}
			}
			var result = "";
			foreach (var word in resultWords)
			{
				result += word + " ";
			}
			return result.Trim();
		}
		static string[] Ones =
		{
			"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
			"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
			"Eighteen", "Nineteen"
		};
		static string[] Tens =
		{
			"Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
			"Eighty", "Ninety"
		};
		static string[] Large =
		{
			"Zero", "Thousand", "Million", "Billion", "Trillion"
		};
	}
}
