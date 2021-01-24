    private object[] GetMetadataCustomAttributes(Type T, string propName)
        {
            if (Attribute.IsDefined(T, typeof(MetadataTypeAttribute)))
            {
                var metadataClassType = 
                (T.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault() as 
                MetadataTypeAttribute).MetadataClassType;
                var metaDataClassProperty = metadataClassType.GetProperty(propName);
                if (metaDataClassProperty != null)
                {
                    return metaDataClassProperty.GetCustomAttributes(true);
                }
            }
            return null;
        }
