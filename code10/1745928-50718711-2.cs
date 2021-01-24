	// Sort to make sure parents always come first
	Array.Sort(input);
	var rootFolders = ParseInputRecursive(input);
	
	foreach (var folder in rootFolders)
	{
		PrintFoldersRecursive(folder);
	}
	
	public static void PrintFoldersRecursive(Folder folder, int depth = 0)
	{
		Console.WriteLine(new string('*', depth++) + folder.Name);
		
		foreach (var subFolder in folder.Folders)
		{
			PrintFoldersRecursive(subFolder, depth);
		}
	}
