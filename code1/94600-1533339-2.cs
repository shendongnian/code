    public MyClass
    {
    	public int? a { get; set; }
    	
    	[System.Xml.Serialization.XmlIgnore]
    	public bool aSpecified { get { return this.a != null; } }
    	
    	public int? b { get; set; }
    	[System.Xml.Serialization.XmlIgnore]
    	public bool bSpecified { get { return this.b != null; } }
    	
    	public int? c { get; set; }
    	[System.Xml.Serialization.XmlIgnore]
    	public bool cSpecified { get { return this.c != null; } }
    }
