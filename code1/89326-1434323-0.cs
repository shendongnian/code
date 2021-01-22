		class DateCompare : IComparer<FileInfo>
		{
			public int Compare(FileInfo a, FileInfo b)
			{ 
				int result = a.LastWriteTime.CompareTo(b.LastWriteTime);
				if (result == 0)
					return StringComparer.OrdinalIgnoreCase.Compare(a.FullName, b.FullName);
				return result;
			}
		}
	
		public static void Main(string[] args)
		{
			DirectoryInfo root = new DirectoryInfo("c:\\Projects\\");
			DateTime start = DateTime.Now;
			long memory = GC.GetTotalMemory(false);
			FileInfo[] allfiles = root.GetFiles("*", SearchOption.AllDirectories);
			DateTime sortStart = DateTime.Now;
			List<FileInfo> files = new List<FileInfo>(20000);
			IComparer<FileInfo> cmp = new DateCompare();
			foreach (FileInfo file in allfiles)
			{
				int pos = ~files.BinarySearch(file, cmp);
				files.Insert(pos, file);
			}
			Console.WriteLine("Count = {0:#,###}, Read = {1}, Sort = {2}, Memory = {3:#,###}", files.Count, sortStart - start, DateTime.Now - sortStart, GC.GetTotalMemory(false) - memory);
		}
