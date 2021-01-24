csharp
using System;
					
public class Program
{
	public static void Main()
	{
		var rand = new Random();
		int test = 0;
		
		//obscured enough that the compiler doesn't "know" that the line will produce an overflow
		//Does not run explicitly as checked, so no runtime OverflowException is thrown
		test = rand.Next(Int32.MaxValue-2, Int32.MaxValue) + 10;
		
		//simple enough that the compiler "knows" that the line will produce an overflow
		//Compilation error (line 16, col 10): The operation overflows at compile time in checked mode
		//test = Int32.MaxValue + 1;
		
		//Explicitly running as unchecked. Compiler allows line that is "known" to overflow.
		unchecked
		{
			test = Int32.MaxValue + 1;
		}
		
		Console.WriteLine(test);
		
		//Explicitly running as unchecked. Still no runtime OverflowException
		unchecked
		{
			test = test - 10;	
		}
		
		Console.WriteLine(test);
		
		//Explicitly running as checked. System.OverflowException: Arithmetic operation resulted in an overflow.
		checked
		{
			test = test + 10;
		}
		
		Console.WriteLine(test);
	}
}
  [1]: https://dotnetfiddle.net/Gmpl5G
