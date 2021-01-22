	public interface IRunnable
	{
		void Run();
	}
	public sealed class Runnable:
		IRunnable
	{
		public void Run()
		{
		}
	}
	
	class Program
	{
		private const int COUNT = 1700000000;
		static void Main(string[] args)
		{
			var r = new Runnable();
			Console.WriteLine("To get real results, compile this in Release mode and");
			Console.WriteLine("run it outside Visual Studio.");
			
			Console.WriteLine();
			Console.WriteLine("Checking direct calls twice");
			{
				DateTime begin = DateTime.Now;
				for (int i = 0; i < COUNT; i++)
				{
					r.Run();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			{
				DateTime begin = DateTime.Now;
				for (int i = 0; i < COUNT; i++)
				{
					r.Run();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking interface calls, getting the interface at every call");
			{
				DateTime begin = DateTime.Now;
				for (int i = 0; i < COUNT; i++)
				{
					IRunnable interf = r;
					interf.Run();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking interface calls, getting the interface once");
			{
				DateTime begin = DateTime.Now;
				IRunnable interf = r;
				for (int i = 0; i < COUNT; i++)
				{
					interf.Run();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking Action (delegate) calls, getting the action at every call");
			{
				DateTime begin = DateTime.Now;
				for (int i = 0; i < COUNT; i++)
				{
					Action a = r.Run;
					a();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking Action (delegate) calls, getting the Action once");
			{
				DateTime begin = DateTime.Now;
				Action a = r.Run;
				for (int i = 0; i < COUNT; i++)
				{
					a();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking Action (delegate) over an interface method, getting both at every call");
			{
				DateTime begin = DateTime.Now;
				for (int i = 0; i < COUNT; i++)
				{
					IRunnable interf = r;
					Action a = interf.Run;
					a();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking Action (delegate) over an interface method, getting the interface once, the delegate at every call");
			{
				DateTime begin = DateTime.Now;
				IRunnable interf = r;
				for (int i = 0; i < COUNT; i++)
				{
					Action a = interf.Run;
					a();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.WriteLine();
			Console.WriteLine("Checking Action (delegate) over an interface method, getting both once");
			{
				DateTime begin = DateTime.Now;
				IRunnable interf = r;
				Action a = interf.Run;
				for (int i = 0; i < COUNT; i++)
				{
					a();
				}
				DateTime end = DateTime.Now;
				Console.WriteLine(end - begin);
			}
			Console.ReadLine();
		}
	}
	
}
