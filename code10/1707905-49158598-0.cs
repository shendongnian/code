    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Configuration
    {
        private ConfigurationParameter[] parametersField;
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Parameter", IsNullable = false)]
        public ConfigurationParameter[] Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigurationParameter
    {
        private string attrName1Field;
        private string attrName2Field;
        private string attrName3Field;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AttrName1
        {
            get
            {
                return this.attrName1Field;
            }
            set
            {
                this.attrName1Field = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AttrName2
        {
            get
            {
                return this.attrName2Field;
            }
            set
            {
                this.attrName2Field = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AttrName3
        {
            get
            {
                return this.attrName3Field;
            }
            set
            {
                this.attrName3Field = value;
            }
        }
    }
