    [Serializable]
    [DataContract]
    public class SomeDto
    {
        [DataMember(Name = "unitCount")]
        public int UnitCount { get; set; }
        [DataMember(Name = "packagingType")]
        public PackagingType PackagingTypeIdEtc { get; set; }
    // ...
