    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace Utils {
    	///<summary>
    	///</summary>
    	public class SerializableDictionary : IXmlSerializable {
    		private readonly IDictionary<int, string> dic;
    		public DiccionarioSerializable() {
    			dic = new Dictionary<int, string>();
    		}
    		public SerializableDictionary(IDictionary<int, string> dic) {
    			this.dic = dic;
    		}
    		public IDictionary<int, string> Dictionary {
    			get { return dic; }
    		}
    		public XmlSchema GetSchema() {
    			return null;
    		}
    		public void WriteXml(XmlWriter w) {
    			w.WriteStartElement("dictionary");
    			foreach (int key in dic.Keys) {
    				string val = dic[key];
    				w.WriteStartElement("item");
    				w.WriteElementString("key", key.ToString());
    				w.WriteElementString("value", val);
    				w.WriteEndElement();
    			}
    			w.WriteEndElement();
    		}
    		public void ReadXml(XmlReader r) {
    			if (r.Name != "dictionary") r.Read(); // move past container
    			r.ReadStartElement("dictionary");
    			while (r.NodeType != XmlNodeType.EndElement) {
    				r.ReadStartElement("item");
    				string key = r.ReadElementString("key");
    				string value = r.ReadElementString("value");
    				r.ReadEndElement();
    				r.MoveToContent();
    				dic.Add(Convert.ToInt32(key), value);
    			}
    		}
    	}
    }
