      public class XmlDictionary<T, V> : Dictionary<T, V>, IXmlSerializable {
        [XmlType("Entry")]
        public struct Entry {
          public Entry(T key, V value) : this() { Key = key; Value = value; }
          [XmlElement("Key")]
          public T Key { get; set; }
          [XmlElement("Value")]
          public V Value { get; set; }
        }
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema() {
          return null;
        }
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader) {
          this.Clear();
          var serializer = new XmlSerializer(typeof(List<Entry>));
          reader.Read();  // Why is this necessary?
          var list = (List<Entry>)serializer.Deserialize(reader);
          foreach (var entry in list) this.Add(entry.Key, entry.Value);
          reader.ReadEndElement();
        }
        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer) {
          var list = new List<Entry>(this.Count);
          foreach (var entry in this) list.Add(new Entry(entry.Key, entry.Value));
          XmlSerializer serializer = new XmlSerializer(list.GetType());
          serializer.Serialize(writer, list);
        }
      }
