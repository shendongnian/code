    Regex r = new Regex("<ref>(?<match>.*?)</ref>");
    foreach (Match m in r.Matches(csv[4]))
    {
    	if (m.Groups.Count > 0)
    	{
    		if (m.Groups["match"].Captures.Count > 0)
    		{
    			foreach (Capture c in m.Groups["match"].Captures)
    			{
    				child.InnerText += c.Value + ", ";
    			}
    			child.InnerText = child.InnerText.Substring(0, child.InnerText.Length - 2).Replace("-> ", "");
    		}
    	}
    }
