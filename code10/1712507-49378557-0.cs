    [XmlRoot(ElementName="key")]
    	public class Key {
    		[XmlAttribute(AttributeName="name")]
    		public string Name { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="settings")]
    	public class Settings {
    		[XmlElement(ElementName="key")]
    		public Key Key { get; set; }
    	}
