    void SomeFuncHelper(Expression<Func<object>> expression)
    {
        string propertyName = /* get name by examining expression */;
        SomeFunc(propertyName);
    }
The lambda expression () => objForStrongTyping.MyItem gets translated into an Expression object which is passed to SomeFuncHelper.  SomeFuncHelper examines the Expression, pulls out the property name, and calls SomeFunc.  In my quick test, the following code works for retrieving the property name, assuming SomeFuncHelper is always called as shown above (i.e. () => someObject.SomeProperty):
    propertyName = ((MemberExpression) ((UnaryExpression) expression.Body).Operand).Member.Name;
