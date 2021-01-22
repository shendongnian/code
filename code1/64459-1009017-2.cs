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
