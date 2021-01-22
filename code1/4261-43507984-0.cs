	public static class Pathy
	{
		public static string Combine(string path1, string path2)
		{
			return path1.Trim().TrimEnd(System.IO.Path.DirectorySeparatorChar)
               + System.IO.Path.DirectorySeparatorChar
               + path2.Trim().TrimStart(System.IO.Path.DirectorySeparatorChar);
		}
		public static string Combine(string path1, string path2, string path3)
		{
			return Combine(Combine(path1, path2), path3);
		}
	}
