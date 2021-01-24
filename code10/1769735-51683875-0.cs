    @model object
    @{
        var elements = ViewData.ModelMetadata.Properties.Where(metadata => !metadata.IsComplexType && !ViewData.TemplateInfo.Visited(metadata)).OrderBy(x => x.Order).ToList();
    
        // Get the metadata for the model
        var collectionMetaData = ViewData.ModelMetadata;
        // Get the collection type
        Type type = collectionMetaData.Model.GetType();
        // Validate its a collection and get the type in the collection
        if (type.IsGenericType)
        {
            type = type.GetInterfaces().Where(t => t.IsGenericType)
                .Where(t => t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Single().GetGenericArguments()[0];
        }
        else if (type.IsArray)
        {
            type = type.GetElementType();
        }
        else
        {
            // its not a valid model
        }
        // Get the metadata for the type in the collection
        ModelMetadata typeMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, type);
    }
    ....
    @foreach(var element in elements)
    {
        // Get the metadata for the element
        ModelMetadata elementMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => element, type);
        ....
