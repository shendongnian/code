    public static string ScrubFileName(string value)
    {
    	char[] invalid = System.IO.Path.GetInvalidFileNameChars();
    	foreach (char item in invalid)
    	{
    		value = value.Replace(item.ToString(), "");
    	}
    	return value;
    }
