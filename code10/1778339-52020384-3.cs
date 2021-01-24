	class Logger : IDisposable
	{
		private FileStream fs;
		private StreamWriter fs;
		
		public Logger()
		{
			// Will create file if one does not exist, otherwise appends to existing file
			fs = new FileStream("log.txt", FileMode.Append, FileAccess.ReadWrite, FileShare.ReadWrite);
			sw = new StreamWriter(fs, Encoding.UTF8);
		}
	
		public void Log(string message)
		{
			sw.WriteLine(message);
			sw.Flush();
			fs.Flush();
		}
		
		public void Dispose()
		{
			sw?.Dispose();
			fs?.Dispose();
		}
	}
