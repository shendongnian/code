    static object HandleEnumViaOtherMeans(object e, List<KeyValuePair<string,int>> colors)
    {
        int x = (int) e + 1;
        var arbitraryName = new AssemblyName(Guid.NewGuid().Replace("-", string.Empty));
        var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(arbitraryName, AssemblyBuilderAccess.Run);
        var builder = assemblyBuilder.DefineDynamicModule(arbitraryName.Name);
        var colorEnum = builder.DefineEnum("Color", TypeAttributes.Public, typeof(int));
        foreach(var color in colors)
        {
            colorEnum.DefineLiteral(color.Key,color.Value);
        }
        var complete = colorEnum.CreateType();
        return Enum.ToObject(complete, x);
    }
