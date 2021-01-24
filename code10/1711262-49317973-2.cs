	public class Program
	{
		public static void DoParallelStuff(string caller)
		{
			for (var i = 1; i<5; i++)
			{ 
				Console.WriteLine("I'm doing stuff for {0} on thread {1}....{2}", caller, Thread.CurrentThread.ManagedThreadId, i); 
				Thread.Sleep(100); 
			}
		}
		
		public static void Background()
		{
			DoParallelStuff("Background");
			Console.WriteLine("Background will now throw an exception.");
			var a = ((string)null).ToString();
		}
		
		public static void Main()
		{
			try
			{
				Action background = Background;
				var result = background.BeginInvoke(null, null);
			    DoParallelStuff("Foreground");
				background.EndInvoke(result);
			}
			catch(System.Exception exception)
			{
				Console.WriteLine("This was caught in the main thread: '{0}'", exception.Message);
			}
			
		}
	}
