    string json = @"{
    	""ItemDetails"": [
    	{
    		""ItemNo"": ""0001"",
    		""Desc"": ""Office Supplies"",
    		""Note"": """",
    		""Units"": ""20""
    	}
    	]}";
    
    XNode node = JsonConvert.DeserializeXNode(json, "root");
    
    // select all ItemDetails
    var itemDetails = node.XPathSelectElements("//ItemDetails");
    
    foreach (XElement item in itemDetails)
    {
        foreach (XNode childNode in item.Nodes().ToList())
        {
            // add attribute to node
            var element = childNode as XElement;
            item.SetAttributeValue(element.Name, element.Value);
    
            // remove the childnode
            element.Remove();
        }
    }
    
    Console.WriteLine(node.Document.ToString());
