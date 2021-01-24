    public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T,TValue>> memberFn, TValue value) {
        var b = memberFn.Body;
        if (b is MethodCallExpression bc && bc.Method.IsSpecialName && bc.Method.Name.StartsWith("get_")) {
            var PI = typeof(T).GetProperty(bc.Method.Name.Substring(4));
            PI.SetValue(target, value, bc.Arguments.Select(a => a.Evaluate<object>()).ToArray());
        }
        else if (b is MemberExpression bm) {
            var pi = bm.Member;
            pi.SetValue(target, value);
        }
    }
