    static void Main(string[] args)
    {
        CreateListFromType(typeof(List<Foo>));
        CreateListFromType(typeof(ObservableCollection<int>));
    }
    static IList CreateListFromType(Type listType)
    {
        // Check we have a type that implements IList
        Type iListType = typeof(IList);
        if (!listType.GetInterfaces().Contains(iListType))
        {
            throw new ArgumentException("No IList", nameof(listType));
        }
        // Check we have a a generic type parameter and get it
        Type elementType = listType.GenericTypeArguments.FirstOrDefault();
        if (elementType == null)
        {
            throw new ArgumentException("No Element Type", nameof(listType));
        }
        // Create a list of the required type and cast to IList
        IList list = Activator.CreateInstance(listType) as IList;
        // Add values
        for (int i = 0; i < 50; i++)
        {
            list.Add(CreateFooFromType(elementType));
        }
        // DO something with list which is now a filled object of type listType 
        return list;
    }
