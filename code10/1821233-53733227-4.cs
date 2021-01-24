        public class StringTypeSerializer<T> : SerializerBase<T> where T:StringType<T>, new()
    {
        /// <summary>Deserializes a value.</summary>
        /// <param name="context">The deserialization context.</param>
        /// <param name="args">The deserialization args.</param>
        /// <returns>A deserialized value.</returns>
        public override T Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
          
            T stringType = new T();
            stringType = stringType.FromString(context.Reader.ReadString());
       
            return stringType;
        }
   
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, T value)
        {
            context.Writer.WriteString(value.ToString());
        }
    }
