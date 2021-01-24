	System.Collections.ArrayList FileList = new System.Collections.ArrayList();
	public void Main()
	{
		string path = @"drive"; // TODO  
		ApplyAllFiles(path, ProcessFile);
		Dts.Variables["User::objDirectoryList"].Value = FileList;
	}    
	public void ProcessFile(string path) 
	{
		/* ... */
	}
	public void ApplyAllFiles(string folder, Action<string> fileAction)
	{
		
		List<string> logger = new List<string>();
		DateTime DateFilter = DateTime.Now.AddMonths(-6);
		foreach (string file in Directory.GetDirectories(folder))
		{
			fileAction(file);
		}
		foreach (string subDir in Directory.GetDirectories(folder))
		{
			string rootfolder = "root folder";
			if (subDir.Contains(rootfolder))
			{   
				FileList.Add(subDir);
				//MessageBox.Show(subDir);
			}
			try
			{
				ApplyAllFiles(subDir, fileAction);
			}
			catch (UnauthorizedAccessException e)
			{
				logger.Add(e.Message);
			}
			catch (System.IO.DirectoryNotFoundException e)
			{
				logger.Add(e.Message);
			}
		}
    }
