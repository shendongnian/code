	private static void referenceToXML(string path, string questionText, string smText)
	{
		AddItem(XDocument.Load(path), questionText, smText).Save(path);
	}
	static XDocument AddItem(XDocument doc, string questionText, string smText)
	{
		var firstNameElement = new XElement("Item");
		firstNameElement.SetAttributeValue("name", questionText);
		var lastNameElement = new XElement("Cathegory", smText);
	    firstNameElement.Add(lastNameElement);
		// Get or create the root element ItemCollection
		var root = doc.GetOrAddElement("ItemCollection");
		// Get or create the Items list
		var items = root.GetOrAddElement("Items");
		// Add the item
		items.Add(firstNameElement);
		
		return doc;
	}
