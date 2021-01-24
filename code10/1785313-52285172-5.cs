    using System.Collections;
    static IList CreateListFromType(Type t)
    {
        // Create a list of the required type and cast to IList
        Type genericListType = typeof(List<>);
        Type concreteListType = genericListType.MakeGenericType(t);
        IList list = Activator.CreateInstance(concreteListType) as IList;
        // Add values
        for (int i = 0; i < 50; i++)
        {
            list.Add(CreateFooFromType(t));
        }
        // DO something with list which is now an List<t> filled with 50 ts
        return list;
    }
