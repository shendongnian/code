    public interface IData
    {
        string Filename { get; set; }
    }
    
    // deserialize me.
    [DataContract]
    public class IncomingData : IData
    {
        [DataMember(Name = "$Filename")]
        public string Filename { get; set; }
    }
    
    // serialize me.
    public class Data : IData
    {
        public string Filename { get; set; }
    }
