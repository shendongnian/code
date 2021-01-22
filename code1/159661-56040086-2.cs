    public static MethodInfo GetOverridingMethod(this Type type, MethodInfo baseMethod) {
        return type.GetOverridingMethods( baseMethod ).FirstOrDefault();
    }
    public static IEnumerable<MethodInfo> GetOverridingMethods(this Type type, MethodInfo baseMethod) {
        var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod;
        return type.GetMethods( flags ).Where( i => baseMethod.IsBaseMethodOf( i ) );
    }
    private static bool IsBaseMethodOf(this MethodInfo baseMethod, MethodInfo method) {
        return baseMethod.DeclaringType != method.DeclaringType && baseMethod == method.GetBaseDefinition();
    }
