    class House
    {
	    public int Id{get;set;}
	    .
	    .
	    .
	    public IList<AttributeValue> AttributeValues {get;set;}	
    }
    class AttributeName
    {
	    public int Id{get;set;}
	    .
	    .
	    .
	    public string Name{get;set;}	
    }
    class AttributeValue
    {
	    public int Id{get;set;}
	    .
	    .
	    .
	    public House House {get;set;}
	    public AttributeName Attribute{get;set;}
	    public string Value {get;set;}
    }
