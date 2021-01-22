    [XmlRoot("MyCollection")]
    public class MyCollection 
    {
        [XmlAttribute()]
        public string MyAttribute { get; set; }
        [XmlElement("string")]
        public Collection<string> unserializedCollectionName { get; set; }
        public MyCollection()
        {
            this.MyAttribute = "SerializeThis";
            this.unserializedCollectionName = new Collection<string>();
            this.unserializedCollectionName.Add("Hello");
            this.unserializedCollectionName.Add("Goodbye");
        }
    }
