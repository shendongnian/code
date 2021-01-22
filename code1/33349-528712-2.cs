    [Serializable, ProtoContract]
    public sealed class ProtoFragment : ISerializable
    {
        [ProtoMember(1, DataFormat=DataFormat.TwosComplement)]
        public int Foo { get; set; }
        [ProtoMember(2)]
        public float Bar { get; set; }
        public ProtoFragment() { }
        private ProtoFragment(
            SerializationInfo info, StreamingContext context)
        {
            Serializer.Merge(info, this);
        }
        void  ISerializable.GetObjectData(
            SerializationInfo info, StreamingContext context)
        {
            Serializer.Serialize(info, this);
        }
    }
