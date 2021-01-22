    public void DeleteDirectories(DirectoryInfo directoryInfo, bool deleteFiles)
	{
		Stack<DirectoryInfo> directories = new Stack<DirectoryInfo>();
		directories.Push(directoryInfo);
		while (directories.Count > 0)
		{
			var current = directories.Peek();
			foreach (var d in current.GetDirectories())
				directories.Push(d);
			if (current != directories.Peek())
				continue;
			if (deleteFiles)
				foreach (var f in current.GetFiles())
				{
					f.Delete();
				}
			if (current.GetFiles().Length > 0 || current.GetDirectories().Length > 0)
				throw new InvalidOperationException("The directory " + current.FullName + " was not empty and could not be deleted.");
			current.Delete();
			directories.Pop();
		}
	}
