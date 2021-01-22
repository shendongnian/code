    class Testing
    {
    	[Test]
    	public void Test()
    	{
    		Assert.AreEqual(
    			"<root><a></a><b></b></root>".SortXml()
    			, "<root><b></b><a></a></root>".SortXml());
    	}
    }
    
    public static class XmlCompareExtension
    {
    	public static string SortXml(this string @this)
    	{
    		var xdoc = XDocument.Parse(@this);
    
    		SortXml(xdoc);
    
    		return xdoc.ToString();
    	}
    
    	private static void SortXml(XContainer parent)
    	{
    		var elements = parent.Elements()
    			.OrderBy(e => e.Name.LocalName)
    			.ToArray();
    
    		Array.ForEach(elements, e => e.Remove());
    
    		foreach (var element in elements)
    		{
    			parent.Add(element);
    			SortXml(element);
    		}
    	}
    }
