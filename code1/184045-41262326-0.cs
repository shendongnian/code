    public static class LoggingExtensions
	{
		static ReaderWriterLock locker = new ReaderWriterLock();
		public static void WriteDebug(string text)
		{
			try
			{
				locker.AcquireWriterLock(int.MaxValue); //You might wanna change timeout value 
				System.IO.File.AppendAllLines(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", ""), "debug.txt"), new[] { text });
			}
			finally
			{
				locker.ReleaseWriterLock();
			}
		}
	}
