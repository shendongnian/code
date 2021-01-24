    public static class ReflectionExtensions
    {
        public static bool IsIndexerPropertyMethod(this MethodInfo method)
        {
            var declaringType = method.DeclaringType;
            if (declaringType is null) return false;
            var indexerProperty = GetIndexerProperty(method.DeclaringType);
            if (indexerProperty is null) return false;
            return method == indexerProperty.GetMethod || method == indexerProperty.SetMethod;
        }
        private static PropertyInfo GetIndexerProperty(this Type type)
        {
            var defaultPropertyAttribute = type.GetCustomAttributes<DefaultMemberAttribute>()
                .FirstOrDefault();
            if (defaultPropertyAttribute is null) return null;
            return type.GetProperty(defaultPropertyAttribute.MemberName, 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }
    }
