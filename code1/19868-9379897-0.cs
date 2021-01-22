        private const string DateTimeOffsetFormatString = "yyyy-MM-ddTHH:mm:sszzz";
        private DateTimeOffset eventTimeField;
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public string eventTime
        {
            get { return eventTimeField.ToString(DateTimeOffsetFormatString); }
            set { eventTimeField = DateTimeOffset.Parse(value); }
        }
