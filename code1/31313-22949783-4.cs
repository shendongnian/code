    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace DataTypes {
    	[XmlRoot("Dictionary")]
    	public class SerializableDictionary<TKey, TValue>
    		: Dictionary<TKey, TValue>, IXmlSerializable {
    		#region IXmlSerializable Members
    		public System.Xml.Schema.XmlSchema GetSchema() {
    			return null;
    		}
    
    		public void ReadXml(XmlReader reader) {
    			XDocument doc = null;
    			using (XmlReader subtreeReader = reader.ReadSubtree()) {
    				doc = XDocument.Load(subtreeReader);
    			}
    			XmlSerializer serializer = new XmlSerializer(typeof(SerializableKeyValuePair<TKey, TValue>));
    			foreach (XElement item in doc.Descendants(XName.Get("Item"))) {
    				using(XmlReader itemReader =  item.CreateReader()) {
    					var kvp = serializer.Deserialize(itemReader) as SerializableKeyValuePair<TKey, TValue>;
    					this.Add(kvp.Key, kvp.Value);
    				}
    			}
    			reader.ReadEndElement();
    		}
    
    		public void WriteXml(System.Xml.XmlWriter writer) {
    			XmlSerializer serializer = new XmlSerializer(typeof(SerializableKeyValuePair<TKey, TValue>));
    			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    			ns.Add("", "");
    			foreach (TKey key in this.Keys) {
    				TValue value = this[key];
    				var kvp = new SerializableKeyValuePair<TKey, TValue>(key, value);
    				serializer.Serialize(writer, kvp, ns);
    			}
    		}
    		#endregion
    
    		[XmlRoot("Item")]
    		public class SerializableKeyValuePair<TKey, TValue> {
    			[XmlAttribute("Key")]
    			public TKey Key;
    
    			[XmlAttribute("Value")]
    			public TValue Value;
    
    			/// <summary>
    			/// Default constructor
    			/// </summary>
    			public SerializableKeyValuePair() { }
			public SerializableKeyValuePair (TKey key, TValue value) {
				Key = key;
				Value = value;
			}
		}
	}
    }
