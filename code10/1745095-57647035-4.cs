    public class CustomODataSerializerProvider : DefaultODataSerializerProvider
    {
        private readonly MongoDataSerializer mongoDataSerializer;
        public CustomODataSerializerProvider(
            IServiceProvider odataServiceProvider)
            : base(odataServiceProvider)
        {
            this.mongoDataSerializer = new MongoDataSerializer(this);
        }
        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.FullName() == typeof(MongoData).FullName)
            {
                return this.mongoDataSerializer;
            }
            return base.GetEdmTypeSerializer(edmType);
        }
    }
