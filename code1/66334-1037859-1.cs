    using System;
    using System.Xml.Serialization;
    public class Simple {
        public string Value { get; set; }
    
        static void Main() {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            overrides.Add(typeof(Simple), "Value", new XmlAttributes {
               XmlAttribute = new XmlAttributeAttribute("path")
            });
            XmlSerializer pathSerializer = new XmlSerializer(
                typeof(Simple), overrides);
            // cache and re-use pathSerializer!!!
    
            Simple obj = new Simple();
            obj.Value = "abc";
            pathSerializer.Serialize(Console.Out, obj);
        }
    }
