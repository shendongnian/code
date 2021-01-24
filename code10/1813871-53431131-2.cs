    using System;
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine(MaskName("Dear John Sanders, welcome to our new service."));
			Console.WriteLine(MaskName("Dear John Sanders, welcome to our new service.", true));
			Console.WriteLine(MaskName("Dear John Matthew Sanders, welcome to our new service."));
			Console.WriteLine(MaskName("Dear John Matthew Sanders, welcome to our new service.", true));
		}
		public static string MaskName(string text, bool maskSurname = false)
		{
			var greeting = text.Substring(0, text.IndexOf(','));
			var message = text.Substring(greeting.Length);
			var parts = greeting.Split(' ');
			for (int i = 1; i < parts.Length; i++) // Start from 1, skipping "Dear"
			{
				if (i == parts.Length - 1 && !maskSurname) continue; // Optionally mask the surname
				greeting = greeting.Replace(parts[i], "*****");			
			}
			return greeting + message;
		}
	}
