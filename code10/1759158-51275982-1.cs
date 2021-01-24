	public class Program
	{
		static async Task Execute(params Func<Task>[] actions)
		{
			var tasks = actions.Select( action => action() );
			await Task.WhenAll(tasks);
		}
	
		public static async Task MainAsync()
		{
			await Execute
			(
				async () => 
				{
					await Task.Delay(3000);
					Console.WriteLine("Function 1 done");
				}
				,
				async () =>
				{
					await Task.Delay(3000);
					Console.WriteLine("Function 2 done");
				}
			);
		}
		
		public static void Main()
		{
			MainAsync().GetAwaiter().GetResult();
		}
	}
