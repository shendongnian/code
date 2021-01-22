    static class Utils
    {
    	public static string MakeFileSystemSafe(this string s)
    	{
    		return new string(s.Where(IsFileSystemSafe).ToArray());
    	}
    	
    	public static bool IsFileSystemSafe(char c)
    	{
    		return !Path.GetInvalidFileNameChars().Contains(c);
    	}
    }
