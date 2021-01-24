    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class DataCenter
        {
    
            private DataCenterImageServer imageServerField;
    
            private DataCenterFeedServer feedServerField;
    
            /// <remarks/>
            public DataCenterImageServer ImageServer
            {
                get
                {
                    return this.imageServerField;
                }
                set
                {
                    this.imageServerField = value;
                }
            }
    
            /// <remarks/>
            public DataCenterFeedServer FeedServer
            {
                get
                {
                    return this.feedServerField;
                }
                set
                {
                    this.feedServerField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DataCenterImageServer
        {
    
            private string ipField;
    
            private string nameField;
    
            private byte imageNumberField;
    
            /// <remarks/>
            public string ip
            {
                get
                {
                    return this.ipField;
                }
                set
                {
                    this.ipField = value;
                }
            }
    
            /// <remarks/>
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
    
            /// <remarks/>
            public byte imageNumber
            {
                get
                {
                    return this.imageNumberField;
                }
                set
                {
                    this.imageNumberField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class DataCenterFeedServer
        {
    
            private string ipField;
    
            private string nameField;
    
            /// <remarks/>
            public string ip
            {
                get
                {
                    return this.ipField;
                }
                set
                {
                    this.ipField = value;
                }
            }
    
            /// <remarks/>
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
