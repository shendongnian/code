    //Tag DataContract and DataMember for serialization
    [DataContract]
    public class DTGeotagImageFileInfo
    { 
        [DataMember]
        public long? GeotagID { get; internal set; }
        [DataMember]
        public string GeotagGuid { get; internal set; }
        [DataMember]
        public string ImageGuid { get; internal set; }
        [DataMember]
        public long GeotagFieldId { get; internal set; }
        [DataMember]
        public double Lat { get; internal set; }
        [DataMember]
        public double Lon { get; internal set; }
    }
