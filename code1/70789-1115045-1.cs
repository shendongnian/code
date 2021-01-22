    [Serializable]
    public class YourClass : ISerializable
    {    
        private Guid _Id = Guid.NewGuid();
    
        public string Id
        {
                get { return _Id; }
                private set { _Id = value; }
        }
    
        public YourClass() // Normal constructor
        {
           // ...
        }
    
        // This constructor is for deserialization only
        private YourClass(SerializationInfo information, StreamingContext context)
        {
            Id = (Guid)information.GetValue("Id", typeof(Guid)); // etc
        }
    
        void ISerializable.GetObjectData(SerializationInfo information,
            StreamingContext context)
        {
            // You serialize stuff like this
            information.AddValue("Id", Id, typeof(Guid)); 
        }
    }
