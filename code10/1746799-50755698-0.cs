    public class Document
    {
        public string Name { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("TheId")]
        public string uniqueIdImpl { get => TheId.ToString(); set => TheId = new UniqueId(value); }
        [XmlIgnore]
        public UniqueId TheId { get; set; }
    }
