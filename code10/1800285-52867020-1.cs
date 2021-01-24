    static object HandleEnumViaReflection(object e, ModuleBuilder builder, List<KeyValuePair<string,int>> colors)
    {
        int x = (int) e + 1;
        var colorEnum = builder.DefineEnum("Color", TypeAttributes.Public, typeof(int));
        foreach(var color in colors)
        {
            colorEnum.DefineLiteral(color.Key,color.Value);
        }
        var complete = colorEnum.CreateType();
        return Enum.ToObject(complete, x);
    }
