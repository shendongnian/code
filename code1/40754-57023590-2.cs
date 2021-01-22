	public enum Test { F1, F2, F3 }
	public class Program
	{
		public static void Main()
		{
			Test t = Test.F3;	
			
			Console.WriteLine(t);
			Console.WriteLine(t.Next());
			Console.WriteLine(t.Previous());
			
			Console.WriteLine("\n");
			
			t = Test.F1;	
			Console.WriteLine(t);
			Console.WriteLine(t.Next());
			Console.WriteLine(t.Previous());
		}
	}
