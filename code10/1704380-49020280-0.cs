    using System.Xml.Serialization;
    
    public partial class xmlRoot {
        
        private object[] itemsField;
        
        [System.Xml.Serialization.XmlElementAttribute("items", typeof(xmlRootItems), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("properties", typeof(xmlRootProperties), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
    
    
    public partial class xmlRootItems {
        
        private xmlRootItemsItem[] itemField;
    
        [System.Xml.Serialization.XmlElementAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public xmlRootItemsItem[] item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    public partial class xmlRootItemsItem {
        
        private string p49113Field;
        
        private string p99323Field;
        
        private string p03345Field;
        
        private string p00532Field;
        
        private string p07741Field;
        
        private string p00001Field;
        
        private string p22345Field;
        
        private string p05589Field;
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p49113 {
            get {
                return this.p49113Field;
            }
            set {
                this.p49113Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p99323 {
            get {
                return this.p99323Field;
            }
            set {
                this.p99323Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p03345 {
            get {
                return this.p03345Field;
            }
            set {
                this.p03345Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p00532 {
            get {
                return this.p00532Field;
            }
            set {
                this.p00532Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p07741 {
            get {
                return this.p07741Field;
            }
            set {
                this.p07741Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p00001 {
            get {
                return this.p00001Field;
            }
            set {
                this.p00001Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p22345 {
            get {
                return this.p22345Field;
            }
            set {
                this.p22345Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string p05589 {
            get {
                return this.p05589Field;
            }
            set {
                this.p05589Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    public partial class xmlRootProperties {
        
        private xmlRootPropertiesProperty[] propertyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("property", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public xmlRootPropertiesProperty[] property {
            get {
                return this.propertyField;
            }
            set {
                this.propertyField = value;
            }
        }
    }
    
    public partial class xmlRootPropertiesProperty {
        
        private string idField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
