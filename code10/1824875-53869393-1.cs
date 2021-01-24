    void Main()
    {
    	var doc = XDocument.Load(@"D:\file.xml");
    	
    	doc =  RemoveNulls.RemoveEmptyNodes(doc);
    	doc.Dump();
    }
    
    // Define other methods and classes here
    class RemoveNulls
    {
    	public static XDocument RemoveEmptyNodes(XDocument doc)
    	{
    		foreach (XElement element in doc.Descendants().ToList()){
    			
    			if(!element.HasAttributes && String.IsNullOrWhiteSpace(element.Value) && !element.HasElements)
    				element.Remove();
    		}
    		return doc;		
    	}
    }
