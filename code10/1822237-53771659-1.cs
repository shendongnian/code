    public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T,TValue>> memberFn, TValue value) {
        var b = memberFn.Body;
        if (b is MethodCallExpression bc && bc.Method.IsSpecialName && bc.Method.Name == "get_Item") {
            var PI = typeof(T).GetProperties().Where(p => p.GetIndexParameters().Length > 0).First();
            PI.SetValue(target, value, bc.Arguments.Select(a => a.Evaluate<object>()).ToArray());
        }
        else if (b is MemberExpression bm) {
            var pi = bm.Member;
            pi.SetValue(target, value);
        }
    }
