    foreach (var file in filesToAdd)
    {
        try
        {
			Directory.Move(file, Path.Combine(folderWithFolders,file)); 
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
    }
