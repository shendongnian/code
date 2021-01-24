    using System;
    using System.Xml.Serialization;
    
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks />
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Network
    {
        /// <remarks />
        [XmlArrayItem("ROUTE", IsNullable = false)]
        public NetworkROUTE[] ROUTES { get; set; }
    }
    
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class NetworkROUTE
    {
        [XmlAttribute]
        public string DIRECTION { get; set; }
    
        public string ENTRANCESIGNAL { get; set; }
    
        public string EXITSIGNAL { get; set; }
    
        [XmlAttribute]
        public string ID { get; set; }
    
        [XmlArrayItem("POINTENDID", IsNullable = false)]
        public NetworkROUTEPOINTENDID[] POINTENDIDS { get; set; }
    
        [XmlAttribute]
        public string ZONE { get; set; }
    }
    
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class NetworkROUTEPOINTENDID
    {
        [XmlAttribute]
        public string POS { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
