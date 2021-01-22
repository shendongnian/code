    static void testBinaryFile(string folderPath)
    {
    	List<string> output = new List<string>();
    	foreach (string filePath in getFiles(folderPath, true))
    	{
    		output.Add(isBinary(filePath).ToString() + "  ----  " + filePath);
    	}
    	Clipboard.SetText(string.Join("\n", output), TextDataFormat.Text);
    }
    public static List<string> getFiles(string path, bool recursive = false)
    {
        return Directory.Exists(path) ?
            Directory.GetFiles(path, "*.*",
            recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList() :
            new List<string>();
    }    
    public static bool isBinary(string path)
    {
    	long length = getSize(path);
    	if (length == 0) return false;
    
    	using (StreamReader stream = new StreamReader(path))
    	{
    		int ch;
    		while ((ch = stream.Read()) != -1)
    		{
    			if (isControlChar(ch))
    			{
    				return true;
    			}
    		}
    	}
    	return false;
    }
    
    public static bool isControlChar(int ch)
    {
    	return (ch > Chars.NUL && ch < Chars.BS)
    		|| (ch > Chars.CR && ch < Chars.SUB);
    }
    
    public static class Chars
    {
    	public static char NUL = (char)0; // Null char
    	public static char BS = (char)8; // Back Space
    	public static char CR = (char)13; // Carriage Return
    	public static char SUB = (char)26; // Substitute
    }
