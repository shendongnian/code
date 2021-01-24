    public static class Extension
    {
        public static bool IsInheritedFrom(this Type type, Type Lookup)
        {
            var baseType = type.BaseType;
            if (baseType == null)
                return false;
    
            if (baseType.IsGenericType
                    && baseType.GetGenericTypeDefinition() == Lookup)
                return true;
    
            return baseType.IsInheritedFrom(Lookup);
        }
    }
    
    var lookup = typeof(Listener<>);
    var listeners = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(x => x.IsClass && !x.IsAbstract && x.IsInheritedFrom(lookup))
        .ToList();
