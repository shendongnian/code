    public static class ReflectionExt
    {
        public static readonly List<string> AccessModifiers = new List<string> { Private, Protected, Internal, Public };
        public const string Private = "private";
        public const string Protected = "protected";
        public const string Internal = "internal";
        public const string Public = "public";
        public static string Accessmodifier(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.SetMethod == null)
                return propertyInfo.GetMethod.Accessmodifier();
            if (propertyInfo.GetMethod == null)
                return propertyInfo.SetMethod.Accessmodifier();
            var max = Math.Max(AccessModifiers.IndexOf(propertyInfo.GetMethod.Accessmodifier()),
                               AccessModifiers.IndexOf(propertyInfo.SetMethod.Accessmodifier()));
            return AccessModifiers[max];
        }
        public static string Accessmodifier(this MethodInfo methodInfo)
        {
            if (methodInfo.IsPrivate)
                return Private;
            if (methodInfo.IsFamily)
                return Protected;
            if (methodInfo.IsAssembly)
                return Internal;
            if (methodInfo.IsPublic)
                return Public;
            throw new ArgumentException("Did not find access modifier", "methodInfo");
        }
    }
