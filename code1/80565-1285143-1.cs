    [Serializable, DataContract] // probably don't need [Serializable]
    public class Group<T>
    {
        [DataMember]
        public HashSet<T> Items { get; private set; }
        protected Group()
        {
            Items = new HashSet<T>();
        }
        public Group(string name) : this()
        {
            Name = name;
        }
        [DataMember]
        public string Name {get ;private set;}
    }
