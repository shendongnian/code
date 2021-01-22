    var foo = GetYourObjectFromSomewhere();
    string bar = ExprToString(() => foo.Property);    // bar = "foo.Property"
    // ...
    public static string ExprToString<T>(Expression<Func<T>> e)
    {
        // use a stack and a loop so that we can cope with nested properties
        // for example, "() => foo.First.Second.Third.Fourth.Property" etc
        Stack<string> stack = new Stack<string>();
        MemberExpression me = e.Body as MemberExpression;
        while (me != null)
        {
            stack.Push(me.Member.Name);
            me = me.Expression as MemberExpression;
        }
        return string.Join(".", stack.ToArray());
    }
