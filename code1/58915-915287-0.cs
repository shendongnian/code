    HtmlDocument doc = new HtmlDocument();
    	doc.Load(new StringReader(@"<span id=""label"">
    <span>
    <a href=""http://variableLink"">Joe Bloggs</a>
    now using
    </span>
    <span>
    '
    <a href=""/variableLink/"">Important Data</a>
    '
    </span>
    <span>
    on
    <a href=""/variableLink"">Important data 2</a>
    </span>
    </span>
    "));
        HtmlNode root = doc.DocumentNode;
        HtmlNodeCollection links;
        links = root.SelectNodes("//span[@id='label']/span[position()>=2]/a/text()");
    	IList<string> fileStrings;
    	if(links != null)
    	{
    	    fileStrings = new List<string>(links.Count);
    	    foreach(HtmlNode link in links)
    		fileStrings.Add(((HtmlTextNode)link).Text);
    	}
    	else
    	    fileStrings = new List<string>(0);
    
    	foreach(string s in fileStrings)
    	    Console.WriteLine(s);
