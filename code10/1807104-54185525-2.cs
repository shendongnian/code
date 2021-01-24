    /// <inheritdoc />
    /// <summary>
    /// OData Entity Serilizer that omits null properties from the response
    /// </summary>
    public class IgnoreEmptyListsCollectionSerializer : ODataCollectionSerializer
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="provider"></param>
        public IgnoreEmptyListsCollectionSerializer(ODataSerializerProvider provider)
            : base(provider) { }
        /// <summary>
        /// Creates an <see cref="ODataCollectionValue"/> for the enumerable represented by <paramref name="enumerable"/>.
        /// </summary>
        /// <param name="enumerable">The value of the collection to be created.</param>
        /// <param name="elementType">The element EDM type of the collection.</param>
        /// <param name="writeContext">The serializer context to be used while creating the collection.</param>
        /// <returns>The created <see cref="ODataCollectionValue"/>.</returns>
        public override ODataCollectionValue CreateODataCollectionValue(IEnumerable enumerable, IEdmTypeReference elementType,
            ODataSerializerContext writeContext)
        {
            var shouldHideEmptyLists = writeContext.Request.GetHeader("HideEmptyLists");
            if (shouldHideEmptyLists != null)
            {
                if (enumerable.IsNullOrEmpty())
                {
                    return null;
                    //ignore
                }
            }
            var result = base.CreateODataCollectionValue(enumerable, elementType, writeContext);            
            return result;
        }
    }
