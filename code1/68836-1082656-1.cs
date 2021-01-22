    public static class FileInfoExtensions
    {
    	public static FileInfo MakeUnique(this FileInfo fileInfo)
    	{
    		if (fileInfo == null)
    		{
    			throw new ArgumentNullException("fileInfo");
    		}
    
    		string newfileName = new FileUtilities().GetNextFileName(fileInfo.FullName);
    		return new FileInfo(newfileName);
    	}
    }
    
    public class FileUtilities
    {
    	public string GetNextFileName(string fullFileName)
    	{
    		if (fullFileName == null)
    		{
    			throw new ArgumentNullException("fullFileName");
    		}
    
    		if (!File.Exists(fullFileName))
    		{
    			return fullFileName;
    		}
    		string baseFileName = Path.GetFileNameWithoutExtension(fullFileName);
    		string ext = Path.GetExtension(fullFileName);
    
    		string filePath = Path.GetDirectoryName(fullFileName);
    		var numbersUsed = Directory.GetFiles(filePath, baseFileName + "*" + ext)
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
    		return Path.Combine(filePath, baseFileName) + numberToUse + ext;
    	}
    }    
