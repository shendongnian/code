    /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Request_Criteria", typeof(Asset_Book_Rule_Request_CriteriaType), Order=Asset_Book_Rule_Request_ReferencesType0)]
        //anr [System.Xml.Serialization.XmlElementAttribute("Request_References", typeof(), Order=0)]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public Asset_Book_Rule_Request_CriteriaType Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
