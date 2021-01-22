    [Serializable]
    public class Example : ISerializable
    {
        // ...
        void ISerializable.GetObjectData(
            SerializationInfo info, StreamingContext context)
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
            
        object IObjectReference.GetRealObject(StreamingContext context)
        {
            return GlobalObject.GetIDItem(_id);
        }
        void ISerializable.GetObjectData(
            SerializationInfo info, StreamingContext context)
        {
            throw new NotSupportedException("Don't serialize me!");
        }
    }
