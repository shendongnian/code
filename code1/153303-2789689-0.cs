        public static string GetPropertySymbol<T,TResult>(Expression<Func<T,TResult>> expression)
        {
            return String.Join(".",
                GetMembersOnPath(expression.Body as MemberExpression)
                    .Select(m => m.Member.Name)
                    .Reverse());
            
        }
        private static IEnumerable<MemberExpression> GetMembersOnPath(MemberExpression expression)
        {
            while(expression != null)
            {
                yield return expression;
                expression = expression.Expression as MemberExpression;
            }
        }
