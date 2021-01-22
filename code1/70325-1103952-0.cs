        [XmlIgnore]
        public string Text { get; set; }
        private static readonly XmlDocument _xmlDoc = new XmlDocument();
        [XmlElement("Text")]
        public XmlCDataSection TextCData
        {
            get
            {
                return _xmlDoc.CreateCDataSection(Text);
            }
            set
            {
                Text = value.Data;
            }
        }
