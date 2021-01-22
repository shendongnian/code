    public static class AttributeExtensions
    {
        #region Methods
        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            var member = memberInfo.FirstOrDefault(m => m.DeclaringType == type);
            var attribute = Attribute.GetCustomAttribute(member, typeof(T), false);
            return attribute is T ? (T)attribute : null;
        }
        #endregion
    }
