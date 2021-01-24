    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/MEDEX.Library.Geo")]
    public class Country
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string GeoType { get; set; }
        [DataMember]
        public RegionBase Parent { get; set; }
        [DataMember]
        public string RegionID { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string ISO { get; set; }
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/MEDEX.Library.Geo")]
    [KnownType(typeof(Region))]
    public class RegionBase
    {
    }
    [DataContract(
        Name = "Region", 
        Namespace = "http://schemas.datacontract.org/2004/07/MEDEX.Library.Geo")]
    public class Region : RegionBase
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string GeoType { get; set; }
        [DataMember]
        public string Code { get; set; }
    }
