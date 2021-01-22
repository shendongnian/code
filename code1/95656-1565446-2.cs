    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:Cheeso._2009oct.ContainerExample.Data")]
    [System.Xml.Serialization.XmlRootAttribute("CONTAINER", Namespace="urn:Cheeso._2009oct.ContainerExample.Data", IsNullable=true)]
    public partial class MyComplexType {
        private MyComplexType[] cONTAINERField;
        private string idField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CONTAINER", IsNullable=true)]
        public MyComplexType[] CONTAINER {
            get {
                return this.cONTAINERField;
            }
            set {
                this.cONTAINERField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
