    private void DefineClass()
    {
        // TypeAttributes.Abstract should not be used here as we want to create
        // type that can be instantiated
        this.typebuilder = this.moduleBuilder.DefineType(
            "A",
            TypeAttributes.Public | TypeAttributes.BeforeFieldInit | TypeAttributes.AnsiClass | TypeAttributes.AutoClass,
            typeof(object),
            null);
    }
    private void DefineMethod()
    {
        MethodBuilder methodBuilder = this.typebuilder.DefineMethod(
            "DoInt",
            MethodAttributes.Public,
            typeof(int), new[] { typeof(int), typeof(string) });
        var il = methodBuilder.GetILGenerator();
        // Arguments are counted from zero. For instance methods, argument0 is
        // reserved for 'this' instance. So to get "string" argument (second "real" argument),
        // you need Ldarg_2
        il.Emit(OpCodes.Ldarg_2);
        // You cannot get MethodInfo for "Count" method with simple GetMethod(),
        // since it is generic method with several overloads.
        var countMethodInfo = typeof(Enumerable)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name == "Count")
            .Where(m => m.GetParameters().Length == 1)
            .Single()
            //We want Count<char>() method, because we want to count characters on string (casted to IEnumerable<char>).
            .MakeGenericMethod(typeof(char));
        il.EmitCall(OpCodes.Call, countMethodInfo, null);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Ret);
    }
    public static object Weave()
    {
        var weaver = new Weaver();
        weaver.Run();
        // return weaver.output as Func<object>;
        // Output is an instance of an (dynamically generated) 'A' class, not a Func<>
        return weaver.output;
    }
