    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    	public class story
    	{
    		[System.Xml.Serialization.XmlAttributeAttribute()]
    		public string id;
    		[System.Xml.Serialization.XmlAttributeAttribute()]
    		public string date;
    		[System.Xml.Serialization.XmlAttributeAttribute()]
    		public string time;
    		public string title;
    		
    		[XmlArrayItem("p")]
    		public string[] text;
    
    	}
