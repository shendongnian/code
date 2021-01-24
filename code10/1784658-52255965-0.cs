          using System;
          using System.Text.RegularExpressions;
					
          public class Program
          {
          	public static void Main()
          	{
          		string st1 = "32P125";
          		string st2 = "N23P33";
          		Regex rg = new Regex(@"\d{2}P\d{3}");
          		// If 'P' is not to be matched literally, reeplace above line with below           one
          		// Regex rg = new Regex(@"\d{2}[A-Za-z]\d{3}");
          		Console.WriteLine(rg.IsMatch(st1));
          		Console.WriteLine(rg.IsMatch(st2));
          	}
          }
