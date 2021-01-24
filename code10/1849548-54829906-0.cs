    public class EnumAsStringSerializationProvider : BsonSerializationProviderBase
    {
        public override IBsonSerializer GetSerializer(Type type, IBsonSerializerRegistry registry)
        {
            if (!type.GetTypeInfo().IsEnum) return null;
    
            var enumSerializerType = typeof(EnumSerializer<>).MakeGenericType(type);
            var enumSerializerConstructor = enumSerializerType.GetConstructor(new[] { typeof(BsonType) });
            var enumSerializer = (IBsonSerializer) enumSerializerConstructor?.Invoke(new object[] { BsonType.String });
    
            return enumSerializer;
        }
    }
