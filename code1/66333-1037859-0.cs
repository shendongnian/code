    using System;
    using System.Xml.Serialization;
    public class Simple {
        public string Value { get; set; }
    
        static void Main() {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attribs = new XmlAttributes();
            attribs.XmlAttribute = new XmlAttributeAttribute("path");
            overrides.Add(typeof(Simple), "Value", attribs);
            XmlSerializer serializer = new XmlSerializer(typeof(Simple), overrides);
            // cache and re-use serializer!!!
    
            Simple obj = new Simple();
            obj.Value = "abc";
            serializer.Serialize(Console.Out, obj);
        }
    }
