    public class AListObject
    {
        [XmlArrayItem(typeof(B))]
        [XmlArrayItem(typeof(C))]
        public List<A> SerializedListObjects { get; set; }
    }
