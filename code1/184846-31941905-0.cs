    public static class StringPathExtensions 
    {
    	public static bool IsSubPathOf(this string path, DirectoryInfo dir)
    	{
    		return path
    			.Replace('/', '\\')
    			.TrimEnd('\\')
    			.StartsWith(dir.FullName
    				.Replace('/', '\\')
    				.TrimEnd('\\', '/')
    		    , StringComparison.OrdinalIgnoreCase);
    	}
    }
