    public static FilterDelegate<T> CreateDelegate<T>(Expression<Func<T, double>> expression)
    {
        // Your `GetMethod` for OrderByDescending did not work for me,
        // so I'll just hand wave about this.
        var orderByDescMethod = typeof(Enumerable)
                                .GetMethods()
                                .Single(m => m.Name == nameof(Enumerable.OrderByDescending) &&
                                             m.GetParameters().Length == 2)
                                .MakeGenericMethod(typeof(T), typeof(double));
        var toArrayMethod = typeof(Enumerable)
                            .GetMethod(nameof(Enumerable.ToArray))
                            .MakeGenericMethod(typeof(T));
        // TODO: if you don't already have one of these
        //       you'll probably want to pull this out and re-use it
        //       rather than making a new one for every delegate
        // TODO: if you do share a module builder I don't think it's thread-safe
        //       so this method will need sufficient locking/synchronization
        var dynamicAssemblyName = new AssemblyName { Name = $"{Guid.NewGuid()}" };
        var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(dynamicAssemblyName, AssemblyBuilderAccess.Run);
        var module = asm.DefineDynamicModule(dynamicAssemblyName.Name);
        // Create a class with a static field to hold our compiled expression
        var typeBuilder = module.DefineType(
            $"{Guid.NewGuid()}",
            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Serializable);
        var compiledExpressionField = typeBuilder.DefineField(
            "CompiledExpression",
            typeof(Func<T, double>),
            FieldAttributes.Static | FieldAttributes.Private);
        var holderType = typeBuilder.CreateType();
        var compiledExpression = expression.Compile();
        // Get the actual field after we've compiled the type
        var compiledExpressionFieldInfo = holderType.GetField(
            compiledExpressionField.Name,
            BindingFlags.Static | BindingFlags.NonPublic);
        // Store the compiled expression in the static field
        compiledExpressionFieldInfo.SetValue(null, compiledExpression);
        var newDelegate = new DynamicMethod($"{Guid.NewGuid()}",
            typeof(IOrderedEnumerable<T>),
            new[] { typeof(IEnumerable<T>) },
            typeof(ILGen), true);
        var il = newDelegate.GetILGenerator();
        // Load the array passed into the Delegate (T[])
        il.Emit(OpCodes.Ldarg_0);
        // Load the compiled expression from a static field
        il.Emit(OpCodes.Ldsfld, compiledExpressionFieldInfo);
        // Call .OrderByDescending()
        il.Emit(OpCodes.Call, orderByDescMethod);
        // Call .ToArray()
        il.Emit(OpCodes.Call, toArrayMethod);
        il.Emit(OpCodes.Ret); // Stores the sorted array
        return (FilterDelegate<T>)newDelegate.CreateDelegate(typeof(FilterDelegate<T>));
    }
