	using System;
	public delegate void Valid(int a);
	public class Test {
		public const int MAX_VALUE = 255;
		public const int MIN_VALUE = 10;
		
		public static void checkInt(int a) {
			Console.Write("checkInt result of {0}: ", a);
			if (a < MAX_VALUE && a > MIN_VALUE)
				Console.WriteLine("max and min value is valid");
			else
				Console.WriteLine("max and min value is not valid");
		}
		
		public static void checkMax(int a) {
			Console.Write("checkMax result of {0}: ", a);
			if (a < MAX_VALUE)
				Console.WriteLine("max value is valid");
			else
				Console.WriteLine("max value is not valid");
		}
		
		public static void checkMin(int a) {
			Console.Write("checkMin result of {0}: ", a);
			if (a > MIN_VALUE)
				Console.WriteLine("min value is valid");
			else
				Console.WriteLine("min value is not valid");
			Console.WriteLine("");
		}
	}
	public class Driver {
		public static void Main(string [] args) {
			Valid v1 = new Valid(Test.checkInt);
			v1 += new Valid(Test.checkMax);
			v1 += new Valid(Test.checkMin);
			v1(1);
			v1(10);
			v1(20);
			v1(30);
			v1(254);
			v1(255);
			v1(256);
		}
	}
