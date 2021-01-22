    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class Foo {
        private string barField;
        private object[] bazField;
        /// <remarks/>
        public string Bar {
            get {
                return this.barField;
            }
            set {
                this.barField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("", typeof(System.Xml.XmlElement), IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute(typeof(Type1), IsNullable=false)]
        public object[] Baz {
            get {
                return this.bazField;
            }
            set {
                this.bazField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Type1 {
        private string childField;
        private string[] textField;
        /// <remarks/>
        public string Child {
            get {
                return this.childField;
            }
            set {
                this.childField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
    }
