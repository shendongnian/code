    Assembly myAssembly = typeof(<Namespace>.<someClass>).GetTypeInfo().Assembly;
    Type[] typelist = GetTypesInNamespace(myAssembly, "<Namespace>");
    for (int i = 0; i < typelist.Length; i++)
    {
        Console.WriteLine(typelist[i].Name);
    }
