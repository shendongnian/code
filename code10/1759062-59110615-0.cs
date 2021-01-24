    public class BsonSerializerRegisterer
    {
        static BsonSerializerRegisterer()
        {
            BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeKind.Utc));
            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
            BsonSerializer.RegisterSerializer(new EnumSerializer<MyAwesomeEnum>(BsonType.String));
        }
        public static void RegisterSerializers()
        {            
        }
    }
