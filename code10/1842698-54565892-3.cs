    static public IEnumerable ConvertToGeneric(this ICollection source, Type collectionType)
    {
        return source.LateCast(collectionType.GetGenericArguments()[0]) as IEnumerable;
    }
    object list = nodeList.ConvertToGeneric(nodeList, typeof(ICollection<XmlNode>));
