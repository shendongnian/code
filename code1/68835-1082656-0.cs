    public static class FileInfoExtensions
    {
    	public static FileInfo MakeUnique(this FileInfo fileInfo)
    	{
    		if (fileInfo == null)
    		{
    			throw new ArgumentNullException("fileInfo");
    		}
    		if (!fileInfo.Exists)
    		{
    			return fileInfo;
    		}
    
    		string baseFileName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
    		string ext = Path.GetExtension(fileInfo.FullName);
    
    		var numbersUsed = Directory.GetFiles(fileInfo.DirectoryName, baseFileName + "*" + ext)
    			.Select(x => Path.GetFileNameWithoutExtension(x).Substring(baseFileName.Length))
    			.Select(x =>
    					{
    						int result;
    						return Int32.TryParse(x, out result) ? result : 0;
    					})
    			.Distinct()
    			.OrderBy(x => x)
    			.ToList();
    
    		var firstGap = numbersUsed
    			.Select((x, i) => new { Index = i, Item = x })
    			.FirstOrDefault(x => x.Index != x.Item);
    		int numberToUse = firstGap != null ? firstGap.Item : numbersUsed.Count;
    		return new FileInfo(Path.Combine(fileInfo.DirectoryName, baseFileName) + numberToUse + ext);
    	}
    }
    
