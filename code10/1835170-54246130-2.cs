    public static class IQueryableExt {
        private static Expression CleanUp(this Expression dbFn, string charsToRemove) {
            var toCharE = Expression.Constant(String.Empty);
            var replaceMI = typeof(string).GetMethod("Replace", new[] { typeof(string), typeof(string) });
            var methodBody = dbFn;
            foreach (var ch in charsToRemove) {
                var fromCharE = Expression.Constant(ch.ToString());
                methodBody = Expression.Call(methodBody, replaceMI, fromCharE, toCharE);
            }
    
            return methodBody;
        }
    
        public static IQueryable<T> WhereCleanedUp<T>(this IQueryable<T> src, Expression<Func<T, string>> fieldFn, Expression<Func<T, bool>> predFn, string charsToRemove) {
            var fieldExpr = fieldFn.Body.Replace(fieldFn.Parameters[0], predFn.Parameters[0]);
            var newBody = predFn.Body.ReplaceByValue(fieldExpr, fieldExpr.CleanUp(charsToRemove));
            return src.Where(Expression.Lambda<Func<T, bool>>(newBody, predFn.Parameters));
        }
    }
