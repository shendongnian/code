    public string GetPath<T, U>(Expression<Func<T, U>> expr)
    {
        Stack<string> stack = new Stack<string>();
        MemberExpression me = expr.Body as MemberExpression;
        while (me != null)
        {
            stack.Push(me.Member.Name);
            me = me.Expression as MemberExpression;
        }
        return string.Join(".", stack.ToArray());
    }
