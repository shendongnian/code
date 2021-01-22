    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using System.Reflection;
    using System.Xml;
    namespace NovelTheory.Xml.Serialization
    {
        public class XmlStylesheetAttribute : Attribute
        {
            public string Href { get; set; }
            public XmlStylesheetAttribute(string href)
            {
                Href = href;
            }
        }
        public static class XmlStylesheetAttributeExtenstions
        {
            public static void SerializeWithStyle(this XmlSerializer serializer, 
                    XmlWriter textWriter, object o)
            {
                AddStyleSheet(textWriter, o);
                serializer.Serialize(textWriter, o);
            }
            public static void SerializeWithStyle(this XmlSerializer serializer, 
                    XmlWriter textWriter, object o, XmlSerializerNamespaces namespaces)
            {
                AddStyleSheet(textWriter, o);
                serializer.Serialize(textWriter, o, namespaces);
            }
            private static void AddStyleSheet(XmlWriter textWriter, object o)
            {
                var dnAttribute = o.GetType()
                                                .GetTypeInfo()
                                                .GetCustomAttribute<XmlStylesheetAttribute>();
                if (dnAttribute != null)
                    textWriter.WriteProcessingInstruction("xml-stylesheet", 
                                            $@"type=""text/xsl"" href=""{dnAttribute.Href}""");
            }
        }
    }
