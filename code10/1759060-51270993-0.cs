    public class YourCustomSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(YourCusomType)) return new YourCusomTypeSerializer();
            // fall back to Mongo's defaults
            return null;
        }
    }
