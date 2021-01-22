    public class ExpressionMemberMerger : ExpressionVisitor
    {
        MemberExpression mem;
        ParameterExpression paramToReplace;
        public Expression Visit<TMember, TParamType>(
            Expression<Func<TParamType, bool>> exp,
            Expression<Func<TMember, TParamType>> mem)
        {
            //get member expression
            this.mem = (MemberExpression)mem.Body;
            //get parameter in exp to replace
            paramToReplace = exp.Parameters[0];
            //replace TParamType with TMember.Param
            var newExpressionBody = Visit(exp.Body);
            //create lambda
            return Expression.Lambda(newExpressionBody, mem.Parameters[0]);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (p == paramToReplace) return mem;
            else return base.VisitParameter(p);
        }
    }
