    public static Binding Add<T>
        (this ControlBindingsCollection dataBindings, object dataSource,
        Expression<Func<Control, object>> controlLambda,
        Expression<Func<T, object>> objectLambda) {
        string controlPropertyName =
              ((MemberExpression)(controlLambda.Body)).Member.Name;
        string bindingTargetName =
              ((MemberExpression)(objectLambda.Body)).Member.Name;
    
        return dataBindings.Add
             (controlPropertyName, dataSource, bindingTargetName);
    }
