        private static object ExtractValue(Expression expression)
        {
            if (expression == null)
            {
                return null;
            }
            var ce = expression as ConstantExpression;
            if (ce != null)
            {
                return ce.Value;
            }
            var ma = expression as MemberExpression;
            if (ma != null)
            {
                var se = ma.Expression;
                object val = null;
                if (se != null)
                {
                    val = ExtractValue(se);
                }
                
                var fi = ma.Member as FieldInfo;
                if (fi != null)
                {
                    return fi.GetValue(val);
                }
                else
                {
                    var pi = ma.Member as PropertyInfo;
                    if (pi != null)
                    {
                        return pi.GetValue(val);
                    }
                }
            }
            var mce = expression as MethodCallExpression;
            if (mce != null)
            {
                return mce.Method.Invoke(ExtractValue(mce.Object), mce.Arguments.Select(ExtractValue).ToArray());
            }
            var le = expression as LambdaExpression;
            if (le != null)
            {
                if (le.Parameters.Count == 0)
                {
                    return ExtractValue(le.Body);
                }
                else
                {
                    return le.Compile().DynamicInvoke();
                }
            }
            var dynamicInvoke = Expression.Lambda(expression).Compile().DynamicInvoke();
            return dynamicInvoke;
        }
