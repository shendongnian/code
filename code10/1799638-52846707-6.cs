    public static class AttributeExtensions
    {
        public static bool IsWritable(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(typeof(WritableAttribute)).Any();
        }
        public static string DisplayName(this MemberInfo memberInfo)
        {
            var displayNameAttribute =
                memberInfo.GetCustomAttributes(typeof(DisplayNameAttribute))
                    .FirstOrDefault() as DisplayNameAttribute;
            return displayNameAttribute == null ? null : displayNameAttribute.DisplayName;
        }
        public static PropertyInfo Property<T>(this T _, string propertyName)
        {
            return typeof(T).GetProperty(propertyName);
        }
        public static FieldInfo Field<T>(this T _, string fieldName)
        {
            return typeof(T).GetField(fieldName);
        }
    }
