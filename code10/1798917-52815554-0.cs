        /* 
        Licensed under the Apache License, Version 2.0
        
        http://www.apache.org/licenses/LICENSE-2.0
        */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="style", Namespace="http://www.w3.org/2000/svg")]
    	public class Style {
    		[XmlAttribute(AttributeName="type")]
    		public string Type { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="rect", Namespace="http://www.w3.org/2000/svg")]
    	public class Rect {
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    		[XmlAttribute(AttributeName="x")]
    		public string X { get; set; }
    		[XmlAttribute(AttributeName="y")]
    		public string Y { get; set; }
    		[XmlAttribute(AttributeName="class")]
    		public string Class { get; set; }
    		[XmlAttribute(AttributeName="width")]
    		public string Width { get; set; }
    		[XmlAttribute(AttributeName="height")]
    		public string Height { get; set; }
    	}
    
    	[XmlRoot(ElementName="g", Namespace="http://www.w3.org/2000/svg")]
    	public class G {
    		[XmlElement(ElementName="rect", Namespace="http://www.w3.org/2000/svg")]
    		public Rect Rect { get; set; }
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    		[XmlElement(ElementName="text", Namespace="http://www.w3.org/2000/svg")]
    		public Text Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="text", Namespace="http://www.w3.org/2000/svg")]
    	public class Text {
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    		[XmlAttribute(AttributeName="transform")]
    		public string Transform { get; set; }
    		[XmlAttribute(AttributeName="class")]
    		public string Class { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="svg", Namespace="http://www.w3.org/2000/svg")]
    	public class Svg {
    		[XmlElement(ElementName="style", Namespace="http://www.w3.org/2000/svg")]
    		public Style Style { get; set; }
    		[XmlAttribute(AttributeName="style")]
    		public string _Style { get; set; }
    		[XmlElement(ElementName="g", Namespace="http://www.w3.org/2000/svg")]
    		public List<G> G { get; set; }
    		[XmlAttribute(AttributeName="version")]
    		public string Version { get; set; }
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    		[XmlAttribute(AttributeName="xmlns")]
    		public string Xmlns { get; set; }
    		[XmlAttribute(AttributeName="xlink", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Xlink { get; set; }
    		[XmlAttribute(AttributeName="x")]
    		public string X { get; set; }
    		[XmlAttribute(AttributeName="y")]
    		public string Y { get; set; }
    		[XmlAttribute(AttributeName="viewBox")]
    		public string ViewBox { get; set; }
    		[XmlAttribute(AttributeName="space", Namespace="http://www.w3.org/XML/1998/namespace")]
    		public string Space { get; set; }
    	}
    
    }
