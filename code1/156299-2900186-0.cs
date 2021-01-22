        [XmlElement("Valid")]
        public string _Valid
        {
            get;
            set;
        }
        [XmlIgnore]
        public bool? Valid
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_Valid))
                {
                    return bool.Parse(_Valid);
                }
                return null;
            }
        }
