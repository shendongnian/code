    void Main()
    {
    	var doc = XDocument.Parse("<?xml version=\"1.0\" encoding=\"UTF-8\"?><settings><key name=\"setting_name\">true</key></settings>");
    	string boolStr = doc.Root.Elements()
                .Where(e => e.Name.LocalName == "key" && e.Attribute("name").Value == "setting_name" )
                .Single().Value;
    	bool value = bool.Parse(boolStr);
    }
