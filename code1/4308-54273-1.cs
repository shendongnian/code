    public static class UriHelper
    {   	
    	public static string NormalizeRelativePath(string path)
    	{
			UriBuilder _builder = new UriBuilder("http://localhost");
    		builder.Path = path;
    		return builder.Uri.AbsolutePath;
    	}
    }
