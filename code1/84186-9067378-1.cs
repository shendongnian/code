    public static class File2
    {
    	private static readonly Encoding _defaultEncoding = new UTF8Encoding(false, true); // encoding used in File.ReadAll*()
    	private static object _bufferSizeLock = new Object();
    	private static int _bufferSize = 1024 * 1024; // 1mb
    	public static int BufferSize 
    	{
    		get
    		{
    			lock (_bufferSizeLock)
    			{
    				return _bufferSize;
    			}
    		}
    		set
    		{
    			lock (_bufferSizeLock)
    			{
    				_bufferSize = value;
    			}
    		}
    	}
    
    	public static void PrependAllLines(string path, IEnumerable<string> contents)
    	{
    		PrependAllLines(path, contents, _defaultEncoding);
    	}
    	
    	public static void PrependAllLines(string path, IEnumerable<string> contents, Encoding encoding)
    	{
    		var temp = Path.GetTempFileName();
    		File.WriteAllLines(temp, contents, encoding);
    		AppendToTemp(path, temp, encoding);
    		File.Replace(temp, path, null);
    	}
    	
    	public static void PrependAllText(string path, string contents)
    	{
    		PrependAllText(path, contents, _defaultEncoding);
    	}
    	
    	public static void PrependAllText(string path, string contents, Encoding encoding)
    	{
    		var temp = Path.GetTempFileName();
    		File.WriteAllText(temp, contents, encoding);
    		AppendToTemp(path, temp, encoding);
    		File.Replace(temp, path, null);
    	}
    	
    	private static void AppendToTemp(string path, string temp, Encoding encoding)
    	{
    		var bufferSize = BufferSize;
    		char[] buffer = new char[bufferSize];
    		
    		using (var writer = new StreamWriter(temp, true, encoding))
    		{
    			using (var reader = new StreamReader(path, encoding))
    			{
    				int bytesRead;
    				while ((bytesRead = reader.ReadBlock(buffer,0,bufferSize)) != 0)
    				{					
    					writer.Write(buffer,0,bytesRead);
    				}
    			}
    		}
    	}
    }
