    public static class UriHelper
    {
    	private static readonly UriBuilder _builder = new UriBuilder("http://localhost");
    	
    	public static string NormalizeRelativePath(string path)
    	{
    		_builder.Path = path;
    		return _builder.Uri.AbsolutePath;
    	}
    }
