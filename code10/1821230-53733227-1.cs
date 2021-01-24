    public class SkinTypeSerializer : SerializerBase<SkinTypes>
    {
        /// <summary>Deserializes a value.</summary>
        /// <param name="context">The deserialization context.</param>
        /// <param name="args">The deserialization args.</param>
        /// <returns>A deserialized value.</returns>
        public override SkinTypes Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
          
            SkinTypes skinTypes = context.Reader.ReadString();
       
            return skinTypes;
        }
   
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, SkinTypes value)
        {
            context.Writer.WriteString(value);
        }
    }
