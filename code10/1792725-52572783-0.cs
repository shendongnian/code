    public List<string> getFiltersList(XmlNode node)
    {
    	List<string> filtersList = new List<string>();
    	foreach (XmlNode inNode in node.SelectNodes("FieldsSearch/Field"))
    	{
    		filtersList.Add(inNode.FirstChild.Value);
    	}
    	return filtersList;
    }
