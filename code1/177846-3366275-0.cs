    try
    {
    	xmlData.ReadToFollowing("SearchResults");
    	Label1.Text = xmlData.GetAttribute("TotalCount");
    	int numberResults = Convert.ToInt32(xmlData.GetAttribute("TotalCount"));
    	if (numberResults > 0)
    	{
    		XDocument xml = XDocument.Parse(xmlData.ReadOuterXml());
    
    		Repeater1.DataSource = xml.Element("SearchResults").Elements("SearchResult");
    		Repeater1.DataBind();
    	}
    	else
    	{
    		Repeater1.DataSource = null;
    		Repeater1.DataBind();
    	}
    }
    catch 
    {
    	// do some catch
    }
