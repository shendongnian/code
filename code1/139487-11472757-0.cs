    using System.Runtime.CompilerServices;
    using System.Reflection;
    public static class AnonymousTypesSupport
    {
        public static bool IsAnonymous(this Type type)
        {
            if (type.IsGenericType)
            {
                var d = type.GetGenericTypeDefinition();
                if (d.IsClass && d.IsSealed && d.Attributes.HasFlag(TypeAttributes.NotPublic))
                {
                    var attributes = d.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false);
                    if (attributes != null && attributes.Length > 0)
                    {
                        //WOW! We have an anonymous type!!!
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool IsAnonymousType<T>(this T instance)
        {
            return IsAnonymous(instance.GetType());
        }
    }
