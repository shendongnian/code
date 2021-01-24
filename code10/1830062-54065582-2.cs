    using System;
	using System.Linq;
	
	public class Test
	{
		public static void Main()
		{ 
			var binary1 = "1010001";
			var binary2 = "0100100";
			var result = binary1
                .Zip(binary2, (b1, b2) => b1 == '1' || b2 == '1' ? '1' : '0')
                .ToArray();
			Console.WriteLine(new string(result));   // "1110101"
		}
	}
