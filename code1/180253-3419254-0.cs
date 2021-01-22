    [DataContract]
    public class DzieckoAndOpiekunCollection : 
        IEnumerable<DzieckoAndOpiekun>, IList<DzieckoAndOpiekun>
    {
        [DataMember]
        List<DzieckoAndOpiekun> collection = new List<DzieckoAndOpiekun>();
    
        [DataMember]
        public List<DzieckoAndOpiekun> Collection
        {
            get { return collection; }
            set { collection = value; }
        }
    ...
