        [XmlIgnore]
        public bool BadBoolField { get; set; }
        [XmlAttribute("badBoolField")]
        public string BadBoolFieldSerializable
        {
            get
            {
                return this.BadBoolField.ToString();
            }
            set
            {
                this.BadBoolField= Convert.ToBoolean(value);
            }
        }
