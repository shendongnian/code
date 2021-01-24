    void Main()
    {
    	var oneNoteProvider = new OneNoteProvider();
    	var pageitems = oneNoteProvider.PageItems.Where(p => p.Name =="TEST");
    	foreach (var item in pageitems)
    	{
    		var pageXMLContent = string.Empty;
    		oneNoteProvider.OneNote.GetPageContent(item.ID, out pageXMLContent, Microsoft.Office.Interop.OneNote.PageInfo.piBasic);
    		
    		var xml = XDocument.Parse(pageXMLContent);
    		var ns = xml.Root.Name.Namespace;
    		var html = new StringBuilder();
    		foreach (XElement el in xml.Descendants(ns + "T").Skip(1)){
    			html.Append($@"{el.Value}<br>");
    		}
    		html.ToString().Dump();
    	}
    }
