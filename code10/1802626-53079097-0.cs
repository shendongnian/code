    private static void InsertDocType(HTMLDocument htmlDocument, HtmlDocument document)
    {
    	// get html node
    	HtmlNode htmlNode = document.DocumentNode.SelectSingleNode("/html");
    
    	// get doctype node from HTMLDocument
    	var doctype = (dynamic)htmlDocument.doctype;
    
    	StringBuilder doctypeText = new StringBuilder();
    	doctypeText.Append("<!DOCTYPE");
    	doctypeText.Append(" ");
    	doctypeText.Append(doctype.name);
    
    	// add PUBLIC
    	if (!string.IsNullOrEmpty(doctype.publicId))
    	{
    		doctypeText.Append(" PUBLIC \"");
    		doctypeText.Append(doctype.publicId);
    		doctypeText.Append("\"");
    	}
    
    	// add sytem id
    	if (!string.IsNullOrEmpty(doctype.systemId))
    	{
    		doctypeText.Append(" \"");
    		doctypeText.Append(doctype.systemId);
    		doctypeText.Append("\"");
    	}
    
    	// add close tag
    	doctypeText.Append(">");
    	doctypeText.Append(Environment.NewLine);
    
    	HtmlCommentNode doctypeNode = document.CreateComment(doctypeText.ToString());
    	document.DocumentNode.InsertBefore(doctypeNode, htmlNode);
    }
