    private static object GetPrimaryKeyValue(TEntity entity)
    {
        MetadataTypeAttribute[] metadataTypes = typeof(TEntity).GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().ToArray();
        MetadataTypeAttribute metadata = metadataTypes.FirstOrDefault();
        if (metadata == null)
        {
            ThrowNotFound();
        }
        PropertyInfo[] properties = metadata.MetadataClassType.GetProperties();
        PropertyInfo primaryKeyProperty =
            properties.SingleOrDefault(x => Attribute.GetCustomAttribute(x, typeof(KeyAttribute)) as KeyAttribute != null);
        if (primaryKeyProperty == null)
        {
            ThrowNotFound();
        }
        object primaryKeyValue = typeof(TEntity).GetProperties().Single(x => x.Name == primaryKeyProperty.Name).GetValue(entity);
        return primaryKeyValue;
    }
    private static void ThrowNotFound()
    {
        throw new InvalidOperationException
                ($"The type {typeof(TEntity)} does not have a property with attribute KeyAttribute to indicate the primary key. You must add that attribute to one property of the class.");
    }
