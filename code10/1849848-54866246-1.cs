    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.02")]
    public partial class AccountIdentification4Choice
    {
        private object itemField;
        [System.Xml.Serialization.XmlElementAttribute("IBAN", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("Othr", typeof(GenericAccountIdentification1), Order = 0)]
        public object Item
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
    }
