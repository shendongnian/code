    public string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> propertyPicker)
    {
         MemberExpression me = (MemberExpression)propertyPicker.Body;
         return me.Member.Name;
    }
