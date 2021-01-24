    class ParameterRewriter<T, U> : ExpressionVisitor
    {
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type.Equals(typeof(T)))
            {
                return Expression.Parameter(typeof(U), node.Name);
            }
            return base.VisitParameter(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression is ParameterExpression paramExp && paramExp.Type.Equals(typeof(T)))
            {
                return Expression.MakeMemberAccess(
                    Expression.Parameter(typeof(U), paramExp.Name),
                    typeof(U).GetMember(node.Member.Name).Single());
            }
            return base.VisitMember(node);
        }
        protected override Expression VisitLambda<L>(Expression<L> node)
        {
            var parameters = node.Parameters.ToList();
            var found = false;
            for (var i = 0; i < parameters.Count; i++)
            {
                if (parameters[i].Type.Equals(typeof(T)))
                {
                    parameters[i] = Expression.Parameter(typeof(U), parameters[i].Name);
                    found = true;
                }
            }
            if (found)
            {
                return Expression.Lambda(node.Body, parameters);
            }
            return base.VisitLambda(node);
        }
    }
