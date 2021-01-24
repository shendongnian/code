	public static List<Folder> ParseInputRecursive(string[] input)
	{
		var foldersInParts = input.Select(f => f.Split(new [] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
		
		return ParseInputRecursive(foldersInParts);
	}
	
	public static List<Folder> ParseInputRecursive(List<List<string>> input)
	{
		var folders = new List<Folder>();
				
		foreach (var folderPartsGroup in input.GroupBy(p => p[0]))
		{
			var folder = new Folder { Name = folderPartsGroup.Key };
			
			// Remove parent name, skip parent itself
			var subFolders = folderPartsGroup.Select(f => f.Skip(1).ToList()).Where(f => f.Count > 0).ToList();
			
			folder.Folders = ParseInputRecursive(subFolders);
			
			folders.Add(folder);
		}
		
		return folders;
	}
