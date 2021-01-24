    public class CustomODataSerializerProvider : DefaultODataSerializerProvider
    {
        private readonly DictionaryOfStringObjectSerializer dictionaryOfStringObjectSerializer;
        public CustomODataSerializerProvider(
            IServiceProvider odataServiceProvider)
            : base(odataServiceProvider)
        {
            this.dictionaryOfStringObjectSerializer = new DictionaryOfStringObjectSerializer(this);
        }
        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.IsComplex() && edmType.FullName() == "System.Collections.Generic.Dictionary_2OfString_Object")
            {
                return this.dictionaryOfStringObjectSerializer;
            }
            return base.GetEdmTypeSerializer(edmType);
        }
    }
