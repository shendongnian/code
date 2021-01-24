    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {
    
            private EnvelopeBody bodyField;
    
            /// <remarks/>
            public EnvelopeBody Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public partial class EnvelopeBody
        {
    
            private AddTwoStr addTwoStrField;
    
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://cpu1147/AB_TestWebApp/")]
            public AddTwoStr AddTwoStr
            {
                get
                {
                    return this.addTwoStrField;
                }
                set
                {
                    this.addTwoStrField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://cpu1147/AB_TestWebApp/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://cpu1147/AB_TestWebApp/", IsNullable = false)]
        public partial class AddTwoStr
        {
    
            private AddTwoStrParameter[] inputParametersField;
    
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Parameter", IsNullable = false)]
            public AddTwoStrParameter[] InputParameters
            {
                get
                {
                    return this.inputParametersField;
                }
                set
                {
                    this.inputParametersField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://cpu1147/AB_TestWebApp/")]
        public partial class AddTwoStrParameter
        {
    
            private string dataTypeField;
    
            private string nameField;
    
            private string valueField;
    
            /// <remarks/>
            public string DataType
            {
                get
                {
                    return this.dataTypeField;
                }
                set
                {
                    this.dataTypeField = value;
                }
            }
    
            /// <remarks/>
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
    
            /// <remarks/>
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
