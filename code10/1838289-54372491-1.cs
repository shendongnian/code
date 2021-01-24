    string json = @"{
    	""ItemDetails"": [
    	{
    		""ItemNo"": ""0001"",
    		""Desc"": ""Office Supplies"",
    		""Note"": """",
    		""Units"": ""20""
    	}
    	]}";
    
    // using xmldocument
    XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "root", true);
    
    // select all ItemDetails
    var itemDetails = doc.SelectNodes("//ItemDetails");
    
    foreach (XmlNode item in itemDetails)
    {
        foreach (XmlNode childNode in item.ChildNodes.Cast<XmlNode>().ToList())
        {
            var attribute = doc.CreateAttribute(childNode.Name);
            attribute.Value = childNode.InnerText;
    
            // add attribute to node
            item.Attributes.Append(attribute);
    
            // remove the childnode
            item.RemoveChild(childNode);
        }
    }
    
    Console.WriteLine(doc.InnerXml);
