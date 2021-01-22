    Expression<Func<string>> expr = () => foo.Bar;
    var me = (MemberExpression)((MemberExpression)expr.Body).Expression;
    var ce = (ConstantExpression)me.Expression;
    var fieldInfo = ce.Value.GetType().GetField(me.Member.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    var value = (Foo)fieldInfo.GetValue(ce.Value);
