    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Step")]
    	public class Step {
    		[XmlElement(ElementName="ACTION")]
    		public string ACTION { get; set; }
    		[XmlElement(ElementName="CLASS_ID")]
    		public string CLASS_ID { get; set; }
    		[XmlAttribute(AttributeName="ID")]
    		public string ID { get; set; }
    	}
    
    	[XmlRoot(ElementName="Demo_Test")]
    	public class Demo_Test {
    		[XmlElement(ElementName="Step")]
    		public List<Step> Step { get; set; }
    	}
    
    }
