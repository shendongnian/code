    [DataContract]
    public class A
    {
        ...
        
        [DataMember]
        private Dictionary<SerializableType, B> _bees;
        ...
        public B GetB(Type type)
        {
            return _bees[type];
        }
        ...
    }
