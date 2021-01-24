    public static class CustomKeysHelper
    {
        public static string GetKey<T>(Expression<Func<T, object>> property)
        {
            var memberInfo = GetMemberInfo(property);
            return GetAttributeKey(memberInfo) ?? memberInfo?.Name;
        }
    
        private static MemberInfo GetMemberInfo<T>(Expression<Func<T, object>> property) =>
            (property.Body as MemberExpression ?? ((UnaryExpression)property.Body).Operand as MemberExpression)?.Member;
    
        private static string GetAttributeKey<T>(MemberInfo member) =>
            member.GetCustomAttributeValue<string>(typeof(MyAttribute), "Key");
    }
    // Usage:
    string cKey = CustomKeysHelper.GetKey<DerivedClassA>(dca => dca.PropertyC);
