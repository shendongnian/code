			var lastRead = DateTime.MinValue;
			Watcher = new FileSystemWatcher(...)
			{
				NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
				Filter = "*.dll",
				IncludeSubdirectories = false,
			};
			Watcher.Changed += (senderObject, ea) =>
			{
				var now = DateTime.Now;
				var lastWriteTime = File.GetLastWriteTime(ea.FullPath);
				if (now == lastWriteTime)
				{
					return;
				}
				if (lastWriteTime != lastRead)
				{
					// do something...
					lastRead = lastWriteTime;
				}
			};
			Watcher.EnableRaisingEvents = true;
