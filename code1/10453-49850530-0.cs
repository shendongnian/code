	public static IEnumerable<KeyValuePair<string, string[]>> GetFileSystemInfosRecursive(string dir, bool depth_first, bool allow_reparse)
	{
		foreach (var item in GetFileSystemObjectsRecursive(new DirectoryInfo(dir), depth_first, allow_reparse))
		{
			string[] result;
			var children = item.Value;
			if (children != null)
			{
				result = new string[children.Count];
				for (int i = 0; i < result.Length; i++)
				{ result[i] = children[i].Name; }
			}
			else { result = null; }
			string fullname;
			try { fullname = item.Key.FullName; }
			catch (IOException) { fullname = null; }
			catch (UnauthorizedAccessException) { fullname = null; }
			yield return new KeyValuePair<string, string[]>(fullname, result);
		}
	}
	public static IEnumerable<KeyValuePair<DirectoryInfo, List<FileSystemInfo>>> GetFileSystemInfosRecursive(DirectoryInfo dir, bool depth_first, bool allow_reparse)
	{
		var stack = depth_first ? new Stack<DirectoryInfo>() : null;
		var queue = depth_first ? null : new Queue<DirectoryInfo>();
		if (depth_first) { stack.Push(dir); }
		else { queue.Enqueue(dir); }
		for (var list = new List<FileSystemInfo>(); (depth_first ? stack.Count : queue.Count) > 0; list.Clear())
		{
			dir = depth_first ? stack.Pop() : queue.Dequeue();
			FileSystemInfo[] children;
			try { children = dir.GetFileSystemInfos(); }
			catch (UnauthorizedAccessException) { children = null; }
			catch (IOException) { children = null; }
			if (children != null) { list.AddRange(children); }
			yield return new KeyValuePair<DirectoryInfo, List<FileSystemInfo>>(dir, children != null ? list : null);
			if (depth_first) { list.Reverse(); }
			foreach (var child in list)
			{
				var asdir = child as DirectoryInfo;
				if (asdir != null && (allow_reparse || (asdir.Attributes & FileAttributes.ReparsePoint) == 0))
				{
					if (depth_first) { stack.Push(asdir); }
					else { queue.Enqueue(asdir); }
				}
			}
		}
	}
