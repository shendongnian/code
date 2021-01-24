    /// <inheritdoc />
    /// <summary>
    /// OData Entity Serializer that omits empty listss properties from the response
    /// </summary>
    public class IgnoreEmptyListsResourceSetSerializer : ODataResourceSetSerializer
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="provider"></param>
        public IgnoreEmptyListsResourceSetSerializer(ODataSerializerProvider provider) : base(provider) { }
        /// <inheritdoc />
        public override void WriteObjectInline(object graph, IEdmTypeReference expectedType, ODataWriter writer,
            ODataSerializerContext writeContext)
        {
            var shouldHideEmptyLists = writeContext.Request.GetHeader("HideEmptyLists");
            if (shouldHideEmptyLists != null)
            {     
                IEnumerable enumerable = graph as IEnumerable; // Data to serialize
                if (enumerable.IsNullOrEmpty())
                {
                    return;
                    //ignore
                }
            }
            base.WriteObjectInline(graph, expectedType, writer, writeContext);
        }
    }
