[System.Xml.Serialization.XmlElementAttribute("Request_Criteria", typeof(Asset_Book_Rule_Request_CriteriaType), Order = 0)]
//[System.Xml.Serialization.XmlElementAttribute("Request_References", typeof(Asset_Book_Rule_Request_ReferencesType), Order = 0)]
[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public Asset_Book_Rule_Request_CriteriaType Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }
