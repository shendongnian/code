    [Serializable]
    public class FunkyTime
    {
        [XmlAttribute]
        public DateTime When { get; set; }
        [XmlAttribute]
        public bool IsStart { get; set; }
        [XmlAttribute]
        public bool IsEnd { get; set; }
    }
