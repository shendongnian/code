    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace yournamespace
    {
    	[XmlRoot(ElementName="key")]
    	public class Key {
    		[XmlAttribute(AttributeName="type", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
    		public string Type { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    		[XmlAttribute(AttributeName="soapenc", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Soapenc { get; set; }
    	}
    
    	[XmlRoot(ElementName="value")]
    	public class Value {
    		[XmlAttribute(AttributeName="type", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
    		public string Type { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    		[XmlAttribute(AttributeName="soapenc", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Soapenc { get; set; }
    	}
    
    	[XmlRoot(ElementName="item")]
    	public class Item {
    		[XmlElement(ElementName="key")]
    		public Key Key { get; set; }
    		[XmlElement(ElementName="value")]
    		public Value Value { get; set; }
    		[XmlAttribute(AttributeName="soapenc", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Soapenc { get; set; }
    	}
    
    	[XmlRoot(ElementName="checkcompanyReturn")]
    	public class CheckcompanyReturn {
    		[XmlElement(ElementName="item")]
    		public List<Item> Item { get; set; }
    		[XmlAttribute(AttributeName="type", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
    		public string Type { get; set; }
    		[XmlAttribute(AttributeName="ns2", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Ns2 { get; set; }
    	}
    
    	[XmlRoot(ElementName="checkcompanyResponse", Namespace="http://DefaultNamespace")]
    	public class CheckcompanyResponse {
    		[XmlElement(ElementName="checkcompanyReturn")]
    		public CheckcompanyReturn CheckcompanyReturn { get; set; }
    		[XmlAttribute(AttributeName="encodingStyle", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    		public string EncodingStyle { get; set; }
    		[XmlAttribute(AttributeName="ns1", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Ns1 { get; set; }
    	}
    
    	[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    	public class Body {
    		[XmlElement(ElementName="checkcompanyResponse", Namespace="http://DefaultNamespace")]
    		public CheckcompanyResponse CheckcompanyResponse { get; set; }
    	}
    
    	[XmlRoot(ElementName="Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    	public class Envelope {
    		[XmlElement(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    		public Body Body { get; set; }
    		[XmlAttribute(AttributeName="soapenv", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Soapenv { get; set; }
    		[XmlAttribute(AttributeName="xsd", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Xsd { get; set; }
    		[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Xsi { get; set; }
    	}
    
    }
