    [DataContract]
    public class Response
    {
        [DataMember(Name = "AX")]
        public AX Ax { get; set; }
    }
    [DataContract]
    public class AX
    {
        [DataMember(Name = "BX")]
        public long Bx { get; set; }
    }
