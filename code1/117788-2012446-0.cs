    var foo = GetYourObjectFromSomewhere();
    string bar = ExprToString(() => foo.Property);    // bar = "foo.Property"
    // ...
    public static string ExprToString<T>(Expression<Func<T>> e)
    {
        Stack<string> stack = new Stack<string>();
        MemberExpression me = e.Body as MemberExpression;
        while (me != null)
        {
            stack.Push(me.Member.Name);
            me = me.Expression as MemberExpression;
        }
        return string.Join(".", stack.ToArray());
    }
