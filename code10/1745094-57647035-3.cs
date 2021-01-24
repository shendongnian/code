    public class MongoDataSerializer: ODataResourceSerializer
    {
        public MongoDataSerializer(ODataSerializerProvider serializerProvider)
            : base(serializerProvider)
        {
        }
        /// <summary>
        /// Serializes the open complex type as an <see cref="ODataUntypedValue"/>.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="expectedType"></param>
        /// <param name="writer"></param>
        /// <param name="writeContext"></param>
        public override void WriteObjectInline(
            object graph,
            IEdmTypeReference expectedType,
            ODataWriter writer,
            ODataSerializerContext writeContext)
        {
            // This cast is safe because the type is checked before using this serializer.
            var mongoData = (MongoData)graph;
            var properties = new List<ODataProperty>();
            foreach (var item in mongoData.Document)
            {
                properties.Add(new ODataProperty
                {
                    Name = item.Key,
                    Value = new ODataUntypedValue
                    {
                        RawValue = JsonConvert.SerializeObject(item.Value),
                    },
                });
            }
            writer.WriteStart(new ODataResource
            {
                TypeName = expectedType.FullName(),
                Properties = properties,
            });
            writer.WriteEnd();
        }
    }
