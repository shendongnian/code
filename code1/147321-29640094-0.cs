    namespace System.Reflection
    {
        // Summary:
        //     Contains static methods for retrieving custom attributes.
        public static class CustomAttributeExtensions
        {
            public static T GetCustomAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute;
        }
    }
