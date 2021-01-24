c#
using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(Convert.FromBase64String("YWE==").Length);
	}
}
Here's a test: https://dotnetfiddle.net/x2X9CT
