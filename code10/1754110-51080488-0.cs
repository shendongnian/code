    public class RichPerson
    {
        public string name;
        [BsonSerializer(typeof(MySerializer))]
        public BigInteger money;
    }
    public class MySerializer : SerializerBase<BigInteger>
    {
        public override BigInteger Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            string val = context.Reader.ReadString();
            return BigInteger.Parse(val);
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, BigInteger value)
        {
            context.Writer.WriteString(value.ToString());
        }
    }
