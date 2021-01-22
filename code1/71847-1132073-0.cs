    public class ParameterToMemberExpressionRebinder : ExpressionVisitor
    {
        ParameterExpression _paramExpr;
        MemberExpression _memberExpr;
        ParameterToMemberExpressionRebinder(ParameterExpression paramExpr, MemberExpression memberExpr) 
        {
            _paramExpr = paramExpr;
            _memberExpr = memberExpr;
        }
        protected override Expression Visit(Expression p)
        {
            return base.Visit(p == _paramExpr ? _memberExpr : p);
        }
        public static Expression<Func<T, bool>> CombinePropertySelectorWithPredicate<T, T2>(
            Expression<Func<T, T2>> propertySelector,
            Expression<Func<T2, bool>> propertyPredicate)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("propertySelector");
            }
            var expr = Expression.Lambda<Func<T, bool>>(propertyPredicate.Body, propertySelector.Parameters);
            var rebinder = new ParameterToMemberExpressionRebinder(propertyPredicate.Parameters[0], memberExpression);
            expr = (Expression<Func<T, bool>>)rebinder.Visit(expr);
            return expr;
        }
        class OrderLine
        {
        }
        class Order
        {
            public List<OrderLine> Lines;
        }
        static void test()
        {
            Expression<Func<Order, List<OrderLine>>> selectOrderLines = o => o.Lines;
            Expression<Func<List<OrderLine>, Boolean>> validateOrderLines = lines => lines.Count > 0;
            var validateOrder = ParameterToMemberExpressionRebinder.CombinePropertySelectorWithPredicate(selectOrderLines, validateOrderLines);
            // validateOrder: {o => (o.Lines.Count > 0)}
        }
    }
