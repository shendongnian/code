		public static long CalcDirSize(string sourceDir, bool recurse = true)
		{
			return _CalcDirSize(new DirectoryInfo(sourceDir), recurse);
		}
		private static long _CalcDirSize(DirectoryInfo di, bool recurse = true)
		{
			long size = 0;
			FileInfo[] fiEntries = di.GetFiles();
			foreach (var fiEntry in fiEntries)
			{
				Interlocked.Add(ref size, fiEntry.Length);
			}
			if (recurse)
			{
				DirectoryInfo[] diEntries = di.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
				System.Threading.Tasks.Parallel.For<long>(0, diEntries.Length, () => 0, (i, loop, subtotal) =>
				{
					if ((diEntries[i].Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) return 0;
					subtotal += __CalcDirSize(diEntries[i], true);
					return subtotal;
				},
					(x) => Interlocked.Add(ref size, x)
				);
			}
			return size;
		}
