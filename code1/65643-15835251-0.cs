    public static bool IsValidXml(string xmlString)
    {
    	Regex tagsWithData = new Regex("<\\w+>[^<]+</\\w+>");
    
    	//Light checking
    	if (string.IsNullOrEmpty(xmlString) || tagsWithData.IsMatch(xmlString) == false)
    	{
    		return false;
    	}
    
    	try
    	{
    		XmlDocument xmlDocument = new XmlDocument();
    		xmlDocument.LoadXml(xmlString);
    		return true;
    	}
    	catch (Exception e1)
    	{
    		return false;
    	}
    }
    
    [TestMethod()]
    public void TestValidXml()
    {
    	string xml = "<result>true</result>";
    	Assert.IsTrue(Utility.IsValidXml(xml));
    }
    
    [TestMethod()]
    public void TestIsNotValidXml()
    {
    	string json = "{ \"result\": \"true\" }";
    	Assert.IsFalse(Utility.IsValidXml(json));
    }
