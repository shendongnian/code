        DynamicAccessor<T> dynAccessor = new DynamicAccessor<T>();
        MethodInfo AppendMethod = typeof(StringBuilder).GetMethod("Append", new[] { typeof(Object) }); //Append method of Stringbuilder
        var method = new DynamicMethod("ClassWriter", typeof(StringBuilder), new[] { typeof(T) }, typeof(T), true);
        var generator = method.GetILGenerator();
        generator.Emit(OpCodes.Newobj, typeof(StringBuilder).GetConstructor(Type.EmptyTypes)); //make our string builder 
        //iterate through all the instance of T's props and sb.Append their values.
        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var info in props)
        {   
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Callvirt, info.GetGetMethod()); //call the Getter
            if (info.PropertyType.IsValueType)
            {
                generator.Emit(OpCodes.Box, info.PropertyType);
            }
            generator.Emit(OpCodes.Callvirt, AppendMethod);        //Call Append 
        }
        generator.Emit(OpCodes.Ret);           //return pointer to sb
