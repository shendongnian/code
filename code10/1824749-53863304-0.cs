    [Serializable()]
    public class Key
    {
        [XmlAttribute("param")]
        public string param { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
