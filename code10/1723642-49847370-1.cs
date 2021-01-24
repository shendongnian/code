    [DataContract]
    public class Level
    {
        [DataMember(Order = 0)]
        public int size { get; set; }
        [DataMember(Order = 1)]
        public int difficulty { get; set; }
        [DataMember(Order = 2)]
        public string title { get; set; }
    }
