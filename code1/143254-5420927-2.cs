    public partial class myText{
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("mailto", typeof(myTextTextMailto))]
        [System.Xml.Serialization.XmlElementAttribute("text", typeof(myTextText))]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
