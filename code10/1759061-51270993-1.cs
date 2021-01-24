    public class YourCustomSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(YourCusomType)) return new YourCusomTypeSerializer();
            // fall back to Mongo's defaults
            return null;
        }
    }
    // Where you previously registered individual serializers you will now register your provider instead
    BsonSerializer.RegisterSerializationProvider(new YourCustomSerializationProvider());
