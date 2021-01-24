	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	namespace WebApplication3.Models
	{
		public class Calculations
		{
			public static int Add(params int[] numbers)
			{
				var sum = 0;
				foreach (var n in numbers)
				{
					sum += n;
				}
				return sum;
			}
			public static int Subtract(params int[] numbers)
			{
				var sum = 0;
				foreach (var n in numbers)
				{
					sum -= n;
				}
				return sum;
			}
			public static int Multiply(params int[] numbers)
			{
				var sum = 0;
				foreach (var n in numbers)
				{
					sum *= n;
				}
				return sum;
			}
			public static int Divide(params int[] numbers)
			{
				var sum = 0;
				foreach (var n in numbers)
				{
					sum /= n;
				}
				return sum;
			}
			public static string[] CheckingOfSomeSort(string userInput, int value, bool isAddition, bool isSubtraction, bool isDivision, bool isMultiplication)
			{
				if (userInput.Contains("+"))
				{
					var addition = userInput.Split('+');
					value = 1;
					isAddition = true;
					return addition;
				}
				else if (userInput.Contains("-"))
				{
					var subtraction = userInput.Split('-');
					value = 2;
					isSubtraction = true;
					return subtraction;
				}
				else if (userInput.Contains("*"))
				{
					var multiplication = userInput.Split('*');
					value = 3;
					isMultiplication = true;
					return multiplication;
				}
				else if (userInput.Contains("/"))
				{
					var division = userInput.Split('/');
					value = 4;
					isDivision = true;
					return division;
				}
				return null;
			}
		}
	}
