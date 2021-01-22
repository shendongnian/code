    public static class FileUtility
    {
    	public static string SetJsVersion(HttpContext context, string filename) {
    		string version = GetJsFileVersion(context, filename);
    		return filename + version;
    	}
    
    	private static string GetJsFileVersion(HttpContext context, string filename)
    	{
    		if (context.Cache[filename] == null)
    		{
    			string filePhysicalPath = context.Server.MapPath(filename);
    
    			string version = "?v=" + GetFileLastModifiedDateTime(context, filePhysicalPath, "yyyyMMddhhmmss");
    
    			return version;
    		}
    		else
    		{
    			return string.Empty;
    		}
    	}
    
    	public static string GetFileLastModifiedDateTime(HttpContext context, string filePath, string dateFormat)
    	{
    		return new System.IO.FileInfo(filePath).LastWriteTime.ToString(dateFormat);
    	}
    }
