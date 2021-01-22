    public static T To<T>(this object obj) {
        Type type = obj.GetType();
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
        MethodInfo method = methods.FirstOrDefault(mi => (mi.Name == "op_Implicit" || mi.Name == "op_Explicit") && mi.ReturnType == typeof(T));
        if (method == null)
            throw new ArgumentException();
        return (T)method.Invoke(null, new[] { obj });
    }
