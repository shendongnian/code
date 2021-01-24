	public class FileMonitor : IDisposable
	{
		private readonly FileStream _file;
		private readonly StreamReader _reader;
	
		private long _position;
		private List<string> _lines;
		
		public FileMonitor(string file)
		{
			if (String.IsNullOrEmpty(nameof(file))) throw new ArgumentNullException(nameof(file));
			
			_lines = new List<string>();
	
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = Path.GetDirectoryName(file);
			watcher.Filter = Path.GetFileName(file);
			watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			//watcher.Created += new FileSystemEventHandler(OnCreated);
			//watcher.Deleted += new FileSystemEventHandler(OnDeleted);
			//watcher.Renamed += new RenamedEventHandler(OnRenamed);
	
			// begin watching.
			watcher.EnableRaisingEvents = true;
			
			// begin reading
			_file = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			_reader = new StreamReader(_file);
			_lines = ReadLines(_reader).ToList();
			_position = _file.Position;
		}
	
		private void OnChanged(object source, FileSystemEventArgs e)
		{
			List<string> update = ReadLines(_reader).ToList();
			 // fix to remove the immidate newline
			if (update.Count() > 0 && String.IsNullOrEmpty(update[0])) update.RemoveAt(0);
			_lines.AddRange(update);
			_position = _file.Position;
			
			// just for debugging, you should remove this
			Console.WriteLine($"File: {e.FullPath} [{e.ChangeType}]");
		}
	
		public IEnumerable<string> Lines { get { return _lines; } }
		
		public void Reset()
		{
			_file.Position = 0;
			_position = _file.Position;
			_lines.Clear();	
		}
	
		private static IEnumerable<string> ReadLines(StreamReader reader)
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				yield return line;
			}
		}
		
		public void Dispose()
		{
			_reader.Dispose();
			_file.Dispose();
		}
	}
