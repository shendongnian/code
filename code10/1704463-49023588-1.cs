		public static void Main()
		{
			
			var a = "ABCD";
			var b = "ABCDEFGHI";
			
			Console.WriteLine( a.FuzzyCompare(b, 0.5F) );
		}
