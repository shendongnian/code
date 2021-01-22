    Type t = column.DataType;    // Int64
    string typeName;
    using (var provider = new CSharpCodeProvider())
    {
        var typeRef = new CodeTypeReference(t);
        typeName = provider.GetTypeOutput(typeRef);
    }
    Console.WriteLine(typeName);    // long
