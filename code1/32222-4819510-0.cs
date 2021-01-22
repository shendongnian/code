    private static XmlNamespaceManager PrepopulateNamespaces( XmlDocument document )
    {
    	XmlNamespaceManager result = new XmlNamespaceManager( document.NameTable );
    	var namespaces = ( from XmlNode n in document.SelectNodes( "//*|@*" )
    			           where n.NamespaceURI != string.Empty
            			   select new
            			   {
            				   Prefix = n.Prefix,
            				   Namespace = n.NamespaceURI
            			   } ).Distinct();
    
    	foreach ( var item in namespaces )
    		result.AddNamespace( item.Prefix, item.Namespace );
    
    	return result;
    }
