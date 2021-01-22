    // C#-ish code that probably doesn't compile
    class Element {
    	public object GetAttribute(string attribute) {
    		if (this.Attributes.HasKey(attribute))
    			return this.Attributes[attribute];
    		else
    			return this.Parent.GetAttribute(attribute);
    	}
    
    	private IDictionary<string,object> Attributes;
    
    	private Element Parent;
    	private IList<Element> Children;	// maybe not needed
    
    	// etc.
    }
			
