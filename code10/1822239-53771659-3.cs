    public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T,TValue>> memberFn, TValue value) {
        var b = memberFn.Body;
        if (b is MethodCallExpression bc && bc.Method.IsSpecialName) {
            var PI = typeof(T).GetProperties().First(pi => bc.Method.Name.Contains(pi.Name));
            PI.SetValue(target, value, bc.Arguments.Select(a => a.Evaluate<object>()).ToArray());
        }
        else if (b is MemberExpression bm) {
            var pi = bm.Member;
            pi.SetValue(target, value);
        }
    }
