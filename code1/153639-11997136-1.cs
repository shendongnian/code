    public class ExpressionTargetTypeMutator : ExpressionVisitor
    {
        private readonly Func<Type, Type> typeConverter;
        private readonly Dictionary<Expression, Expression> _convertedExpressions 
            = new Dictionary<Expression, Expression>();
        public ExpressionTargetTypeMutator(Func<Type, Type> typeConverter)
        {
            this.typeConverter = typeConverter;
        }
        // Clear the ParameterExpression cache between calls to Visit.
        // Not thread safe, but you can probably fix it easily.
        public override Expression Visit(Expression node)
        {
            bool outermostCall = false;
            if (false == _isVisiting)
            {
                this._isVisiting = true;
                outermostCall = true;
            }
            try
            {
                return base.Visit(node);
            }
            finally
            {
                if (outermostCall)
                {
                    this._isVisiting = false;
                    _convertedExpressions.Clear();
                }
            }
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            var sourceType = node.Member.ReflectedType;
            var targetType = this.typeConverter(sourceType);
            var converted = Expression.MakeMemberAccess(
                base.Visit(node.Expression),
                targetType.GetProperty(node.Member.Name));
            return converted;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            Expression converted;
            if (false == _convertedExpressions.TryGetValue(node, out converted))
            {
                var sourceType = node.Type;
                var targetType = this.typeConverter(sourceType);
                converted = Expression.Parameter(targetType, node.Name);
                _convertedExpressions.Add(node, converted);
            }
            return converted;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsGenericMethod)
            {
                var convertedTypeArguments = node.Method.GetGenericArguments()
                                                        .Select(this.typeConverter)
                                                        .ToArray();
                var genericMethodDefinition = node.Method.GetGenericMethodDefinition();
                var newMethod = genericMethodDefinition.MakeGenericMethod(convertedTypeArguments);
                return Expression.Call(newMethod, node.Arguments.Select(this.Visit));
            }
            return base.VisitMethodCall(node);
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            var valueExpression = node.Value as Expression;
            if (null != valueExpression)
            {
                return Expression.Constant(this.Visit(valueExpression));
            }
            return base.VisitConstant(node);
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return Expression.Lambda(this.Visit(node.Body), node.Name, node.TailCall, node.Parameters.Select(x => (ParameterExpression)this.VisitParameter(x)));
        }
    }
