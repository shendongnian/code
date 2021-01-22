    [Serializable]
    public class Example : ISerializable
    {
        // ...
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(ExampleDeserializationProxy));
            info.AddValue("ID", this.GetID());
        }
    }
    // ...
    [Serializable]
    public class ExampleDeserializationProxy : IObjectReference, ISerializable
    {
        private readonly int _id;
        private ExampleDeserializationProxy(
            SerializationInfo info, StreamingContext context)
        {
            _id = info.GetInt32("ID");
        }
            
        public object GetRealObject(StreamingContext context)
        {
            return GlobalObject.GetIDItem(_id);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotSupportedException("Don't serialize me!");
        }
    }
