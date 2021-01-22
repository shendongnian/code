	private void ClearFolder(string FolderName)
	{
		DirectoryInfo dir = new DirectoryInfo(FolderName);
		foreach(FileInfo fi in dir.GetFiles())
		{
			try
			{
				fi.Delete();
			}
			catch(Exception) { } // Ignore all exceptions
		}
		foreach(DirectoryInfo di in dir.GetDirectories())
		{
			ClearFolder(di.FullName);
			try
			{
				di.Delete();
			}
			catch(Exception) { } // Ignore all exceptions
		}
	}
