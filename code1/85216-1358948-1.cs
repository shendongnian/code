    public Type MergeTypes(params Type[] types)
    {
        AppDomain domain = AppDomain.CurrentDomain;
        AssemblyBuilder builder = 
            domain.DefineDynamicAssembly(new AssemblyName("CombinedAssembly"),
            AssemblyBuilderAccess.RunAndSave);
        ModuleBuilder moduleBuilder = builder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("CombinedType");
        foreach (var type in types)
        {
            var props = GetProperties(type);
            foreach (var prop in props)
            {
                typeBuilder.DefineField(prop.Key, prop.Value, FieldAttributes.Public);
            }
        }
        return typeBuilder.CreateType();
        
    }
    private Dictionary<string, Type> GetProperties(Type type)
    {
        return type.GetProperties().ToDictionary(p => p.Name, p => p.PropertyType);
    }
