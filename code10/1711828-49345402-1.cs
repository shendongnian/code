	public class Program
	{
		public static Dictionary<int,string> A = new Dictionary<int,string>
		{
			{ 1,"ex1" },
			{ 2,"EX2" },
			{ 3,"ex3" },
		};
		
		public static Dictionary<int,string> B = new Dictionary<int,string>
		{
			{ 1,"ex1" },
			{ 2,"ex2" },
			{ 4,"ex4" }
		};
			
		public static void Main()
		{
			A.MergeInto(B);
			
			foreach (var entry in B )
			{
				Console.WriteLine("{0}={1}", entry.Key, entry.Value);
			}
		}
	}
