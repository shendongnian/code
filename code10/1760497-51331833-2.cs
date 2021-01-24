        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class configuration
        {
            private configurationSetting[] settingField;
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("setting")]
            public configurationSetting[] setting
            {
                get
                {
                    return this.settingField;
                }
                set
                {
                    this.settingField = value;
                }
            }
        }
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class configurationSetting
        {
            private string valueField;
            private string nameField;
            /// <remarks/>
            public string value
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
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string name
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
        }
