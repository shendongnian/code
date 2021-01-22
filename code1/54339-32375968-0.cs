        // Usage first.Compose(second, Expression.And)
        public static Expression<T> Compose<T>(this Expression<T> First, Expression<T> Second, Func<Expression, Expression, Expression> Merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            Dictionary<ParameterExpression,ParameterExpression> map = First.Parameters.Select((f, i) => new { f, s = Second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            // replace parameters in the second lambda expression with parameters from the first
            Expression secondBody = ParameterRebinder.ReplaceParameters(map, Second.Body);
            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(Merge(First.Body, secondBody), First.Parameters);
        }
        
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> First, Expression<Func<T, bool>> Second)
        {
            return First.Compose(Second, Expression.And);
        }
        
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> First, Expression<Func<T, bool>> second)
        {
            return First.Compose(second, Expression.Or);
        }
        
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }
