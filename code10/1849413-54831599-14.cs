    private static System.Collections.ConcurrentDictionary<Type, Action<object>> ConstructorSetterDictionary { get; private set; }
    public static void SetConstructorValues<T_SetClass>(
                this T_SetClass instanceToSetValuesFor
        )
    {
        var instanceType = typeof(T_SetClass);
        Action<object> constructorSetterAction;
        if (!ConstructorSetterDictionary.TryGetValue(
                    instanceType
                ,   out constructorSetterAction
            ))
        {
            throw new Exception("Populate the dictionary!  Also change this Exception message; it's from a StackOverflow example and not really designed to actually be written like this.");
        }
        constructorSetterAction(instanceToSetValuesFor);
    }
