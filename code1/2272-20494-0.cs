        public static string TrimPath(string path)
		{
			int someArbitaryNumber = 10;
			string directory = Path.GetDirectoryName(path);
			string fileName = Path.GetFileName(path);
			if (directory.Length > someArbitaryNumber)
			{
				return String.Format(@"{0}...\{1}", 
					directory.Substring(0, someArbitaryNumber), fileName);
			}
			else
			{
				return path;
			}
		}
