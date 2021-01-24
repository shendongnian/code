	public static List<DirectoryInfo> DirectorySearch(DirectoryInfo dir)
	{
		List<DirectoryInfo> subs = new List<DirectoryInfo>();
		subs.Add(dir);
		foreach (DirectoryInfo x in dir.GetDirectories())
		{
			foreach (DirectoryInfo y in DirectorySearch(x))
			{
				subs.Add(y);
			}
		}
		return subs;
	}
