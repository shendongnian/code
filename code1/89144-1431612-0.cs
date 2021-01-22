		private static Boolean FileInUse(FileInfo file)
		{
			Boolean inUse = false;
			try
			{
				using (file.OpenRead()) {}
			}
			catch (Exception exception)
			{
				inUse = true;
			}
			return inUse;
		}
