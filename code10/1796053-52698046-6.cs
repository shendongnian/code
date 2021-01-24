    public static IList ToList(Array array)
    {
        Type elementType = array.GetType().GetElementType();
        Type listType = typeof(List<>).MakeGenericType(new[] { elementType });
        IList list = (IList)Activator.CreateInstance(listType);
        foreach (var enumValue in array)
        {
            list.Add(enumValue);
        }
        return list;
    }
