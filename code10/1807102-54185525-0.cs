    /// <summary>
    /// Provider that selects the IgnoreNullEntityPropertiesSerializer that omits null properties on resources from the response
    /// </summary>
    public class MySerializerProvider : DefaultODataSerializerProvider
    {
        private readonly IgnoreNullsSerializer _propertiesSerializer;
        private readonly IgnoreEmptyListsResourceSetSerializer _ignoreEmptyListsSerializer;
        private readonly IgnoreEmptyListsCollectionSerializer _ignoreEmptyListsCollectionSerializer;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="rootContainer"></param>
        public MySerializerProvider(IServiceProvider rootContainer)
            : base(rootContainer)
        {
            _ignoreEmptyListsSerializer = new IgnoreEmptyListsResourceSetSerializer(this);
            _propertiesSerializer = new IgnoreNullsSerializer(this);
            _ignoreEmptyListsCollectionSerializer = new IgnoreEmptyListsCollectionSerializer(this);
        }
        /// <summary>
        /// Mark edmtype to apply the serialization on
        /// </summary>
        /// <param name="edmType"></param>
        /// <returns></returns>
        public override ODataEdmTypeSerializer GetEdmTypeSerializer(Microsoft.OData.Edm.IEdmTypeReference edmType)
        {
            // Support for Entity types AND Complex types
            if (edmType.Definition.TypeKind == EdmTypeKind.Entity || edmType.Definition.TypeKind == EdmTypeKind.Complex)
            {
                return _propertiesSerializer;
            }
            if (edmType.Definition.TypeKind == EdmTypeKind.Collection)
            {
                if(edmType.Definition.AsElementType().IsDecimal() || edmType.Definition.AsElementType().IsString())
                    return _ignoreEmptyListsCollectionSerializer;
                return _ignoreEmptyListsSerializer;
            }            
            var result = base.GetEdmTypeSerializer(edmType);
            return result;
        }
    }
