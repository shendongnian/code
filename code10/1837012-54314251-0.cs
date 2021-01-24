    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks />
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Network
    {
        private NetworkROUTE[] rOUTESField;
    
        /// <remarks />
        [XmlArrayItem("ROUTE", IsNullable = false)]
        public NetworkROUTE[] ROUTES
        {
            get { return this.rOUTESField; }
            set { this.rOUTESField = value; }
        }
    }
    
    /// <remarks />
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NetworkROUTE
    {
        private string dIRECTIONField;
    
        private string eNTRANCESIGNALField;
    
        private string eXITSIGNALField;
    
        private string idField;
    
        private NetworkROUTEPOINTENDID[] pOINTENDIDSField;
    
        private string zONEField;
    
        /// <remarks />
        [XmlAttribute]
        public string DIRECTION
        {
            get { return this.dIRECTIONField; }
            set { this.dIRECTIONField = value; }
        }
    
        /// <remarks />
        public string ENTRANCESIGNAL
        {
            get { return this.eNTRANCESIGNALField; }
            set { this.eNTRANCESIGNALField = value; }
        }
    
        /// <remarks />
        public string EXITSIGNAL
        {
            get { return this.eXITSIGNALField; }
            set { this.eXITSIGNALField = value; }
        }
    
        /// <remarks />
        [XmlAttribute]
        public string ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    
        /// <remarks />
        [XmlArrayItem("POINTENDID", IsNullable = false)]
        public NetworkROUTEPOINTENDID[] POINTENDIDS
        {
            get { return this.pOINTENDIDSField; }
            set { this.pOINTENDIDSField = value; }
        }
    
        /// <remarks />
        [XmlAttribute]
        public string ZONE
        {
            get { return this.zONEField; }
            set { this.zONEField = value; }
        }
    }
    
    /// <remarks />
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class NetworkROUTEPOINTENDID
    {
        private string pOSField;
    
        private string valueField;
    
        /// <remarks />
        [XmlAttribute]
        public string POS
        {
            get { return this.pOSField; }
            set { this.pOSField = value; }
        }
    
        /// <remarks />
        [XmlText]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
