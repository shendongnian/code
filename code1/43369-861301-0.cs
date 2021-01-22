    using System;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Collections.Generic;
    
    using nrw_rime_extract.utils;
    using nrw_rime_extract.xml.generated_bindings;
    
    namespace nrw_rime_extract.xml
    {
        internal interface ExtractXmlReader
        {
            rimeType read(string xmlFilename);
        }
    
        /// <summary>
        /// RimeExtractXml provides bindings to the RIME Extract XML as defined by
        /// $/Release 2.7/Documentation/Technical/SCHEMA and DTDs/nrw-rime-extract.xsd
        /// </summary>
        internal class ExtractXmlReader_XmlSerializerImpl : ExtractXmlReader
        {
            private Log log = Log.getInstance();
    
            public rimeType read(string xmlFilename) {
                log.write("DEBUG: ExtractXmlReader_XmlSerializerImpl.read(" + xmlFilename + ")");
                Stream stream = null;
                try {
                    stream = new FileStream(xmlFilename, FileMode.Open);
                    return read(stream);
                } finally {
                    if (stream != null) stream.Close();
                }
            }
    
            internal rimeType read(Stream xmlInputStream) {
                // create an instance of the XmlSerializer class, specifying the type of object to be deserialized.
                XmlSerializer serializer = new XmlSerializer(typeof(rimeType));
                serializer.UnknownNode += new XmlNodeEventHandler(handleUnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(handleUnknownAttribute);
                // use the Deserialize method to restore the object's state with data from the XML document.
                return (rimeType)serializer.Deserialize(xmlInputStream);
            }
    
            protected void handleUnknownNode(object sender, XmlNodeEventArgs e) {
                log.write("XML_ERROR: Unknown Node at line " + e.LineNumber + " position " + e.LinePosition + " : " + e.Name + "\t" + e.Text);
            }
    
            protected void handleUnknownAttribute(object sender, XmlAttributeEventArgs e) {
                log.write("XML_ERROR: Unknown Attribute at line " + e.LineNumber + " position " + e.LinePosition + " : " + e.Attr.Name + "='" + e.Attr.Value + "'");
            }
    
        }
    
        /// <summary>
        /// xtractXmlReader provides bindings to the extract.xml returned by the RIME server; as defined by:
        ///   $/Release X/Documentation/Technical/SCHEMA and DTDs/nrw-rime-extract.xsd
        /// </summary>
        internal class ExtractXmlReader_XmlTextReaderXmlSerializerHybridImpl : ExtractXmlReader
        {
            private Log log = Log.getInstance();
    
            public rimeType read(string xmlFilename) {
                log.write("DEBUG: ExtractXmlReader_XmlTextReaderXmlSerializerHybridImpl.read(" + xmlFilename + ")");
                XmlTextReader reader = null;
                try {
                    reader = new XmlTextReader(xmlFilename);
                    return read(reader);
                } finally {
                    if (reader != null) reader.Close();
                }
            }
    
            public rimeType read(XmlTextReader reader) {
                rimeType result = new rimeType();
                // a deserializer for featureClass, feature, etc, "doclets"
                Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();
                serializers.Add(typeof(featureClassType), newSerializer(typeof(featureClassType)));
                serializers.Add(typeof(featureType), newSerializer(typeof(featureType)));
                    
                List<featureClassType> featureClasses = new List<featureClassType>();
                List<featureType> features = new List<featureType>();
                while (!reader.EOF) {
                    if (reader.MoveToContent() == XmlNodeType.Element) { // skip junk nodes.
                        if (reader.Name.Equals("featureClass")) {
                            StringReader elementReader = new StringReader(reader.ReadOuterXml());
                            XmlSerializer deserializer = serializers[typeof(featureClassType)];
                            featureClasses.Add((featureClassType)deserializer.Deserialize(elementReader));
                            continue; // ReadOuterXml advances the reader, so don't read again.
                        } else if (reader.Name.Equals("feature")) {
                            StringReader elementReader = new StringReader(reader.ReadOuterXml());
                            XmlSerializer deserializer = serializers[typeof(featureType)];
                            features.Add((featureType)deserializer.Deserialize(elementReader));
                            continue; // ReadOuterXml advances the reader, so don't read again.
                        } else {
                            log.write("WARNING: unknown element '" + reader.Name + "' was skipped during parsing.");
                        }
                    }
                    reader.Read(); // skip non-element-nodes and unknown-elements.
                }
                result.featureClasses = featureClasses.ToArray();
                result.features = features.ToArray();
                return result;
            }
    
            private XmlSerializer newSerializer(Type elementType) {
                XmlSerializer serializer = new XmlSerializer(elementType);
                serializer.UnknownNode += new XmlNodeEventHandler(handleUnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(handleUnknownAttribute);
                return serializer;
            }
    
            protected void handleUnknownNode(object sender, XmlNodeEventArgs e) {
                log.write("XML_ERROR: Unknown Node at line " + e.LineNumber + " position " + e.LinePosition+" : " + e.Name + "\t" + e.Text);
            }
    
            protected void handleUnknownAttribute(object sender, XmlAttributeEventArgs e) {
                log.write("XML_ERROR: Unknown Attribute at line " + e.LineNumber + " position " + e.LinePosition + " : " + e.Attr.Name + "='" + e.Attr.Value + "'");
            }
    
        }
    
    }
