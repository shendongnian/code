	public class Application
	{
		public static int currentValue = 0;
		public static void Main()
		{
			Console.WriteLine("Test 1: ++x");
			(++currentValue).TestMethod();
			Console.WriteLine("\nTest 2: x++");
			(currentValue++).TestMethod();
			Console.WriteLine("\nTest 3: ++x");
			(++currentValue).TestMethod();
			Console.ReadKey();
		}
	}
	public static class ExtensionMethods 
	{
		public static void TestMethod(this int passedInValue) 
		{
			Console.WriteLine("Current:{0} Passed-in:{1}",
				Application.currentValue,
				passedInValue);
		}
	}
