    string elementTypeName = Console.ReadLine();
    Type elementType = Type.GetType(elementTypeName);
    Type[] types = new Type[] { typeof(int) };
    Type listType = typeof(List<>);
    Type genericType = listType.MakeGenericType(types);
    IProxy  proxy = (IProxy)Activator.CreateInstance(genericType);
