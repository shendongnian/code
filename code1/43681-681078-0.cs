		static class Program
		{
			[STAThread]
			static void Main()
			{
				FileSystemWatcher FSW = new FileSystemWatcher("c:\\", "*.cs");
				FswHandler Handler = new FswHandler();
				FSW.Changed += Handler.OnEvent;
				FSW.Created += Handler.OnEvent;
				FSW.Deleted += Handler.OnEvent;
				FSW.Renamed += Handler.OnEvent;
				FSW.EnableRaisingEvents = true;
				System.Threading.Thread.Sleep(555000);
				// change the file manually to see which events are fired
				FSW.EnableRaisingEvents = false;
			}
		}
		public class FswHandler
		{
			public void OnEvent(Object source, FileSystemEventArgs Args)
			{
				Console.Out.WriteLine(Args.ChangeType.ToString());
			}
		}
	}
