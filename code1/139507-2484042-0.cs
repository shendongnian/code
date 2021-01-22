    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.IO;
    
    namespace WFTest {
    	[Serializable]
    	class SerializableLinkedList<T>: LinkedList<T>, ISerializable, IXmlSerializable {
    		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
    			info.AddValue("value", this.ToList());
    		}
    		// Implied by ISerializable, but interfaces can't actually define constructors:
    		SerializableLinkedList(SerializationInfo info, StreamingContext context)
    			: base((IEnumerable<T>)info.GetValue("value", typeof(List<T>))) { }
    
    		System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema() { return null; }
    
    		void IXmlSerializable.ReadXml(XmlReader reader) {
    			this.Clear(); // Start with an empty list
    			reader.ReadStartElement(); // Skips the opening tag
    			while (reader.LocalName=="item") { // Retrieve all elements:
    				T value;
    				if(reader.IsEmptyElement) { // If element is empty...
    					value=default(T); // the item's value falls back to default(T)
    					reader.ReadStartElement(); // and consume the (empty) element
    				} else {
    					// IIRC, ReadInnerXml() consumes the outer tag, despite not returning them.
    					value=(T)((new XmlSerializer(typeof(T))).Deserialize(new StringReader(reader.ReadInnerXml())));
    				}
    				this.AddLast(value);
    			}
    			reader.ReadEndElement(); // Consumes the remaining closing tag from the reader
    		}
    
    		void IXmlSerializable.WriteXml(XmlWriter writer) {
    			foreach(T item in this) {
    				// Format the item itself:
    				StringBuilder sb=new StringBuilder();
    				(new XmlSerializer(typeof(T))).Serialize(XmlWriter.Create(sb), item);
    				XmlDocument doc=new XmlDocument();
    				doc.LoadXml(sb.ToString());
    				// and now write it to the stream within <item>...</item> tags
    				writer.WriteStartElement("item");
    				writer.WriteRaw(doc.DocumentElement.OuterXml);
    				writer.WriteEndElement(); // </item>
    			}
    		}
    	}
    }
