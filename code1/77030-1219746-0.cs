    XmlDocument xmlDoc = youtubeService.GetSearchResults(search.Term, "published", 1, 50);
    XmlNodeList listNodes = xmlDoc.GetElementsByTagName("entry");
    foreach (XmlNode node in listNodes)
    {
    	// get child nodes
    	foreach (XmlNode childNode in node.ChildNodes)
    	{
    	}
    
    	// get specific child nodes
    	XPathNavigator navigator = node.CreateNavigator();
    	XPathNodeIterator iterator = navigator.Select(/* xpath selector according to the elements/attributes you need */);
    
    	while (iterator.MoveNext())
    	{
    		// f.e. iterator.Current.GetAttribute(), iterator.Current.Name and iterator.Current.Value available here
    	}
    }
