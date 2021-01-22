    namespace BasketOfFruits {
        using System.Xml.Serialization;
        
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
        public partial class Basket {
            
            private string[] fruitField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Fruit")]
            public string[] Fruit {
                get {
                    return this.fruitField;
                }
                set {
                    this.fruitField = value;
                }
            }
        }
    }
