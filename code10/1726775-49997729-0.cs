    //Have  DataContract and DataMember for serialization
    [DataContract]
    public class DTGeotagImageFileInfo
    { 
        [DataMember]
        public long? GeotagID { get;  set; }
       [DataMember]
        public string GeotagGuid { get; set; }
        [DataMember]
        public string ImageGuid { get; set; }
        [DataMember]
        public long GeotagFieldId { get;  set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Lon { get; set; }
    }
