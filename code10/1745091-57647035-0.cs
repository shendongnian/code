    public class DictionaryOfStringObjectSerializer : ODataResourceSerializer
    {
        public DictionaryOfStringObjectSerializer(ODataSerializerProvider serializerProvider)
            : base(serializerProvider)
        {
        }
        public override void WriteObjectInline(
            object graph,
            IEdmTypeReference expectedType,
            ODataWriter writer,
            ODataSerializerContext writeContext)
        {
            // This cast is safe because the type is checked before using this serializer.
            var dictionary = (IDictionary<string, object>)graph;
            var properties = new List<ODataProperty>();
            foreach (var(key, value) in dictionary)
            {
                properties.Add(new ODataProperty
                {
                    Name = key,
                    Value = new ODataUntypedValue
                    {
                        RawValue = JsonConvert.SerializeObject(value),
                    },
                });
            }
            writer.WriteStart(new ODataResource
            {
                TypeName = "Edm.Untyped",
                Properties = properties,
            });
            writer.WriteEnd();
        }
    }
