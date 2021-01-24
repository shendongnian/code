    using System.Reflection.Emit;
    public static Dictionary<string, Func<T, object>> GetGetMethods<T>()
    {
        var getMethods = new Dictionary<string, Func<T, object>>();
        foreach (var prop in typeof(T).GetProperties())
        {    
            Func<T, object> del;
            if (prop.PropertyType.IsValueType)
            {
                var dynMethod = new DynamicMethod(string.Format("Dynamic_Get_{0}_{1}", typeof(T).Name, prop.Name), typeof(object), new[] { typeof(T) }, typeof(T).Module);
                var ilGen = dynMethod.GetILGenerator();
                ilGen.Emit(OpCodes.Ldarg_0);
                ilGen.Emit(OpCodes.Callvirt, prop.GetGetMethod());
                ilGen.Emit(OpCodes.Box, prop.PropertyType);
                ilGen.Emit(OpCodes.Ret);
                del = (Func<T, object>)dynMethod.CreateDelegate(typeof(Func<T, object>));
            }
            else
            {
                del = (Func<T, object>)Delegate.CreateDelegate(typeof(Func<T, object>), null, prop.GetGetMethod());
            }
            getMethods[prop.Name] = del;
        }
        return getMethods;
    }
