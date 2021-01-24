	public class Calculator
	{
		private Dictionary<string, Func<float,float,float>> _map = new Dictionary<string, Func<float,float,float>>
		{
			{ "add", (a,b) => a+b },
			{ "subtract", (a,b) => a-b },
			{ "multiply", (a,b) => a*b },
			{ "divide", (a,b) => a/b },
		};
		
		public float Compute(float[] numbers, string opCode)
		{
			var operation = _map[opCode];
			
			float accumulator = numbers[0];
			foreach (var n in numbers.Skip(1))
			{
				accumulator = operation(accumulator, n);	
			}
			return accumulator;
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var c = new Calculator();
			Console.WriteLine(c.Compute( new float[] { 2,2 }, "add"));
			Console.WriteLine(c.Compute( new float[] { 3,3 }, "multiply"));
			Console.WriteLine(c.Compute( new float[] {-2,2 }, "subtract"));
			Console.WriteLine(c.Compute( new float[] { 9,3 }, "divide"));
		}
	}
