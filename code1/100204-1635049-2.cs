    internal class DerivativeVisitor : ExpressionVisitor
    {
        private ParameterExpression _parameter;
        private bool _totalDerivative;
        public DerivativeVisitor(ParameterExpression parameter, bool totalDerivative)
        {
            if (_totalDerivative)
                throw new NotImplementedException();
            _parameter = parameter;
            _totalDerivative = totalDerivative;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
            case ExpressionType.Add:
            case ExpressionType.Subtract:
                return Expression.MakeBinary(node.NodeType, Visit(node.Left), Visit(node.Right));
            case ExpressionType.Multiply:
                return Expression.Add(Expression.Multiply(node.Left, Visit(node.Right)), Expression.Multiply(Visit(node.Left), node.Right));
            case ExpressionType.Divide:
                return Expression.Divide(Expression.Subtract(Expression.Multiply(Visit(node.Left), node.Right), Expression.Multiply(node.Left, Visit(node.Right))), Expression.Power(node.Right, Expression.Constant(2)));
            case ExpressionType.Power:
                if (node.Right is ConstantExpression)
                {
                    return Expression.Multiply(node.Right, Expression.Multiply(Visit(node.Left), Expression.Subtract(node.Right, Expression.Constant(1))));
                }
                else if (node.Left is ConstantExpression)
                {
                    return Expression.Multiply(node, MathExpressions.Log(node.Left));
                }
                else
                {
                    return Expression.Multiply(node, Expression.Add(
                        Expression.Multiply(Visit(node.Left), Expression.Divide(node.Right, node.Left)),
                        Expression.Multiply(Visit(node.Right), MathExpressions.Log(node.Left))
                        ));
                }
            default:
                throw new NotImplementedException();
            }
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            return MathExpressions.Zero;
        }
        protected override Expression VisitInvocation(InvocationExpression node)
        {
            MemberExpression memberExpression = node.Expression as MemberExpression;
            if (memberExpression != null)
            {
                var member = memberExpression.Member;
                if (member.DeclaringType != typeof(Math))
                    throw new NotImplementedException();
                switch (member.Name)
                {
                case "Log":
                    return Expression.Divide(Visit(node.Expression), node.Expression);
                case "Log10":
                    return Expression.Divide(Visit(node.Expression), Expression.Multiply(Expression.Constant(Math.Log(10)), node.Expression));
                case "Exp":
                case "Sin":
                case "Cos":
                default:
                    throw new NotImplementedException();
                }
            }
            throw new NotImplementedException();
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _parameter)
                return MathExpressions.One;
            return MathExpressions.Zero;
        }
    }
