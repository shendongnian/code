    static public IEnumerable ConvertToGeneric(this ICollection source, Type type)
    {
        return source.LateCast(type.GetGenericArguments()[0]) as IEnumerable;
    }
    object list = nodeList.ConvertToGeneric(nodeList, typeof(ICollection<XmlNode>));
