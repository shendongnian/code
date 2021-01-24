	public class Program
	{
		public static void Main()
		{
			TestAsync().GetAwaiter().GetResult();
		}
		
		private static async Task TestAsync() 
		{
			await Task.Delay(5000);
		}
	}
