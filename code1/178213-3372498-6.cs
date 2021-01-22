    public void SetPropertyFromDbValue<T, TProperty>(
        T obj,
        Expression<Func<T, TProperty>> property,
        TProperty value
    )
    {
        MemberExpression member = (MemberExpression)expression.Body;
        PropertyInfo property = (PropertyInfo)member.Member;
        property.SetValue(obj, value, null);
    }
