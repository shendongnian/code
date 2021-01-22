    [DataContract]
    public partial class Root
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public Partial[] Partials { get; set; }
        [DataMember]
        public IList<ulong> Numbers { get; set; }
    }
    
