        public static Type GetIndexerType(this Type collectionType)
        {
            if (typeof(ICollection).IsAssignableFrom(collectionType))
            {
                var indexerProperty = collectionType.GetProperties().FirstOrDefault(x => x.Name == "Item");
                if (indexerProperty != null)
                {
                    return indexerProperty.PropertyType;
                }
            }
            return null;
        }
