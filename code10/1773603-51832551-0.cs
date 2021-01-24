	public class Program
	{
		public static void IterateOverArray(System.Array a)
		{
			foreach (var i in a)
			{
				Console.WriteLine(i);
			}
		}
		
		public static void Main()
		{
			var tests = new System.Array []
			{
				new int[] {1,2,3,4,5,6,7,8},
				new int[,]
				{
					{1,2},{3,4},{5,6},{7,8}
				},
				new int[,,]
				{
					{  {1,2},{3,4} },
					{  {5,6},{7,8} }
				}
			};
			
			
			foreach (var t in tests)
			{
				Console.WriteLine("Dumping array with rank {0} to console.", t.Rank);
				IterateOverArray(t);
			}
		}
	}
