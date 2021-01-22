    Assembly asm = Assembly.GetExecutingAssembly();
    List<string> namespaceList = new List<string>();
    foreach (Type type in asm.GetTypes())
    {
        namespaceList.Add(type.Namespace);
    }
