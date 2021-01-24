    using System.Reflection.Emit;
    public static Dictionary<string, Func<T, object>> GetGetMethods<T>()
    {
        var getMethods = new Dictionary<string, Func<T, object>>();
        foreach (var prop in typeof(T).GetProperties())
        {               
            var dynMethod = new DynamicMethod(string.Format("Dynamic_Get_{0}_{1}", typeof(T).Name, prop.Name), typeof(object), new[] { typeof(T) }, typeof(T).Module);
            var ilGen = dynMethod.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Callvirt, prop.GetGetMethod());
            if (prop.PropertyType.IsValueType)
                ilGen.Emit(OpCodes.Box, prop.PropertyType);
            ilGen.Emit(OpCodes.Ret);
            var del = (Func<T, object>)dynMethod.CreateDelegate(typeof(Func<T, object>));
            getMethods[prop.Name] = del;
        }
        return getMethods;
    }
