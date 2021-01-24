    public static string SplitByBreak(string text, int length)
    {
    	List<string> ignoreList = new List<string>()
    	{
    		"<b>", 
    		"</b>", 
    		"<i>", 
    		"</i>"
    	};
    	string br = "<br/>";
    	string newText = string.Empty;
    	string newLine = string.Empty;
    
    	// Make sure that <br/> is the standard break.
    	text = text.Replace("<br>", br);
    
    	string[] split = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
    	for (int i = 0; i < split.Length; i++)
    	{
    		string testLine = string.Format("{0} {1}", newLine, split[i]).Trim();
    		string temp = testLine;
    		int lastIndexBr = testLine.LastIndexOf(br);
    
    		// Count from the last index of <br/>.
    		if (lastIndexBr >= 0)
    		{
    			temp = temp.Substring(lastIndexBr + br.Length);
    		}
    
    		// Do not include the length from the ignore list. -Eph 10.19.2018
    		foreach (string s in ignoreList)
    		{
    			temp = temp.Replace(s, string.Empty);
    		}
    
    		if (temp.Length > length)
    		{
    			newText = string.Format("{0} {1} {2}{2}", newText, newLine, br).Trim();
    			newLine = split[i];
    		}
    		else
    		{
    			testLine = string.Format("{0} {1}", newLine, split[i]).Trim();
    			newLine = testLine;
    		}
    	}
    
    	newText = string.Format("{0} {1}", newText, newLine).Trim();
    
    	return newText;
    }
