    [DataContract]
    public class BookInfo
    {
        [DataMember]
        public string Name { get; set; }
    }
    [DataContract]
    public class BookingResult
    {
        [DataMember]
        public bool isSucceed { get; set; }
    }
