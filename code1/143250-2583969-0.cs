    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="StrucDoc.Paragraph", Namespace="urn:hl7-org:v3")]
    public partial class StrucDocParagraph {
        private StrucDocCaption captionField;
        private object[] itemsField;
        private string idField;
        // ...fields for other attributes...
        /// <remarks/>
        public StrucDocCaption caption {
            get {
                return this.captionField;
            }
            set {
                this.captionField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("br", typeof(StrucDocBr))]
        [System.Xml.Serialization.XmlElementAttribute("sub", typeof(StrucDocSub))]
        [System.Xml.Serialization.XmlElementAttribute("sup", typeof(StrucDocSup))]
        // ...other possible nodes...
        [System.Xml.Serialization.XmlTextAttribute(typeof(string))]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="ID")]
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        // ...properties for other attributes...
    }
