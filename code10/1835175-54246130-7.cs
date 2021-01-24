    public static class IQueryableExt {
        // body only for LINQ to Objects use
        public static string RemoveAll(this string src, string removeChars) => removeChars.Aggregate(src, (ans,ch) => ans.Replace(ch.ToString(), ""));
    
        private static Expression CleanUp(this Expression dbFn, string charsToRemove) {
            var toCharE = Expression.Constant(String.Empty);
            var replaceMI = typeof(string).GetMethod("Replace", new[] { typeof(string), typeof(string) });
    
            var methodBody = dbFn;
            foreach (var ch in charsToRemove)
                methodBody = Expression.Call(methodBody, replaceMI, Expression.Constant(ch.ToString()), toCharE);
    
            return methodBody;
        }
    
        /// <summary>
        /// ExpressionVisitor to expand x.RemoveAll("x..z") to x.Replace("x","")...Replace("z","") in
        /// an Expression.
        /// </summary>
        private class RemoveAllVisitor : ExpressionVisitor {
            public override Expression Visit(Expression node) {
                if (node?.NodeType == ExpressionType.Call) {
                    var callnode = (MethodCallExpression)node;
                    if (callnode.Method.Name == "RemoveAll" && callnode.Method.DeclaringType == typeof(IQueryableExt))
                        if (callnode.Arguments[1] is ConstantExpression ce && ce.Type == typeof(string))
                            return callnode.Arguments[0].CleanUp(ce.Value.ToString());
                }
    
                return base.Visit(node);
            }
        }
    
        private static T ExpandRemoveAll<T>(this T orig) where T : Expression => (T)new RemoveAllVisitor().Visit(orig);
        public static IQueryable<T> WhereRemoveAll<T>(this IQueryable<T> src, Expression<Func<T, bool>> predFn) => src.Where(predFn.ExpandRemoveAll());
    }
