    [SecurityCritical]
    private static string InternalReadAllText(string path, Encoding encoding, bool checkHost)
    {
    	string result;
    	using (StreamReader streamReader = new StreamReader(path, encoding, true, StreamReader.DefaultBufferSize, checkHost))
    	{
    		result = streamReader.ReadToEnd();
    	}
    	return result;
    }
