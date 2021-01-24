    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class hashTree {
        private hashTreeHTTPSamplerProxy[] hTTPSamplerProxyField;
        private hashTree[] hashTree1Field;
        private hashTreeThreadGroup[] threadGroupField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("HTTPSamplerProxy", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public hashTreeHTTPSamplerProxy[] HTTPSamplerProxy {
            get {
                return this.hTTPSamplerProxyField;
            }
            set {
                this.hTTPSamplerProxyField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("hashTree")]
        public hashTree[] hashTree1 {
            get {
                return this.hashTree1Field;
            }
            set {
                this.hashTree1Field = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ThreadGroup", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public hashTreeThreadGroup[] ThreadGroup {
            get {
                return this.threadGroupField;
            }
            set {
                this.threadGroupField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class hashTreeHTTPSamplerProxy {
        private longProp[] longPropField;
        private stringProp[] stringPropField;
        private boolProp[] boolPropField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("longProp", IsNullable = true)]
        public longProp[] longProp {
            get {
                return this.longPropField;
            }
            set {
                this.longPropField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("stringProp", IsNullable = true)]
        public stringProp[] stringProp {
            get {
                return this.stringPropField;
            }
            set {
                this.stringPropField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("boolProp", IsNullable = true)]
        public boolProp[] boolProp {
            get {
                return this.boolPropField;
            }
            set {
                this.boolPropField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class longProp {
        private string nameField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
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
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class stringProp {
        private string nameField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
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
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public partial class boolProp {
        private string nameField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
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
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class hashTreeThreadGroup {
        private stringProp[] stringPropField;
        private longProp[] longPropField;
        private boolProp[] boolPropField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("stringProp", IsNullable = true)]
        public stringProp[] stringProp {
            get {
                return this.stringPropField;
            }
            set {
                this.stringPropField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("longProp", IsNullable = true)]
        public longProp[] longProp {
            get {
                return this.longPropField;
            }
            set {
                this.longPropField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("boolProp", IsNullable = true)]
        public boolProp[] boolProp {
            get {
                return this.boolPropField;
            }
            set {
                this.boolPropField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class TestPlan {
        private object[] itemsField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("boolProp", typeof(boolProp), IsNullable = true)]
        [System.Xml.Serialization.XmlElementAttribute("hashTree", typeof(hashTree))]
        [System.Xml.Serialization.XmlElementAttribute("longProp", typeof(longProp), IsNullable = true)]
        [System.Xml.Serialization.XmlElementAttribute("stringProp", typeof(stringProp), IsNullable = true)]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
