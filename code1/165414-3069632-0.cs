	public class BaseClass
	{
		protected static ConsoleWriter consoleWriter = new ConsoleWriter("");
		public static void Write(string text)
		{
			consoleWriter.Write(text);
		}
	}
	public class NewClass : BaseClass
	{
		protected new static ConsoleWriter anotherConsoleWriter = new ConsoleWriter("> ");
	}
