        public bool FileIsLocked(string fileName)
		{
			FileStream fs;
			try
			{
				fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
				fs.Dispose();
			}
			catch (IOException)
			{
				return true;
			}
			return false;
		}
