    [Serializable]
    [XmlType(Namespace="urn://MySchema")]
    public class MyObject
    {
        [XmlIgnore]
        public DateTime RecordTime { get; set; }
        
        //property for serialization purposes
        [XmlElement(ElementName="RecordTime")]
        public string XmlRecordTime
        {
            get { return this.RecordTime.ToString("o"); }
            set { this.RecordTime = new DateTime.Parse(value); }
        }
    }
