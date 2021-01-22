    public class SerializableClass
    {
        private List<object> thisIsAListOfSerializableObjects = new List<object>();
        [System.Xml.Serialization.XmlArray] //This line makes it serializable as an array
        public List<object> ThisIsAPublicPropertyVisibleToTheSerialzer
        {
            get { return thisIsAListOfSerializableObjects; }
            set { thisIsAListOfSerializableObjects = value; }
        }
    }
