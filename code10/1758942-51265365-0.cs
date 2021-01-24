    public static Type GetCollectionItemType(Type collectionType)
    {
        var intIndexer = collectionType.GetMethod("get_Item", new[] { typeof(int) });
        //var stringIndexer = collectionType.GetMethod("get_Item", new[] { typeof(string) });
        return intIndexer?.ReturnType ?? null; // null mean the type has no int indexer
    }
