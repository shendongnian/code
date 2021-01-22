    public static class Helpers
    {
        public static DependencyProperty FindDependencyProperty(this DependencyObject target, string propName)
        {
            FieldInfo fInfo = target.GetType().GetField(propName, BindingFlags.Static | BindingFlags.FlattenHierarchy | BindingFlags.Public);
            if (fInfo == null) return null;
            return (DependencyProperty)fInfo.GetValue(null);
        }
        public static bool HasDependencyProperty(this DependencyObject target, string propName)
        {
            return FindDependencyProperty(target, propName) != null;
        }
        public static string GetStaticMemberName<TMemb>(Expression<Func<TMemb>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null) throw new ArgumentException("'expression' should be a member expression");
            return body.Member.Name;
        }
    }
