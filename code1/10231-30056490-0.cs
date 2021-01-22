    public bool XMLCompare(XElement primary, XElement secondary)
    {
    	if (primary.HasAttributes) {
    		if (primary.Attributes.Count != secondary.Attributes.Count)
    			return false;
    		foreach (XAttribute attr in primary.Attributes) {
    			if (secondary.Attribute(attr.Name.LocalName) == null)
    				return false;
    			if (attr.Value.ToLower != secondary.Attribute(attr.Name.LocalName).Value.ToLower)
    				return false;
    		}
    	}
    	if (primary.HasElements) {
    		if (primary.Elements.Count != secondary.Elements.Count)
    			return false;
    		for (i = 0; i <= primary.Elements.Count - 1; i++) {
    			if (XMLCompare(primary.Nodes(i), secondary.Nodes(i)) == false)
    				return false;
    		}
    	}
    	return true;
    }
