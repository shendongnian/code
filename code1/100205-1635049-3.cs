    internal class SimplifyVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            ConstantExpression leftConstant = left as ConstantExpression;
            ConstantExpression rightConstant = right as ConstantExpression;
            if (leftConstant != null && rightConstant != null
                && (leftConstant.Value is double) && (rightConstant.Value is double))
            {
                double leftValue = (double)leftConstant.Value;
                double rightValue = (double)rightConstant.Value;
                switch (node.NodeType)
                {
                case ExpressionType.Add:
                    return Expression.Constant(leftValue + rightValue);
                case ExpressionType.Subtract:
                    return Expression.Constant(leftValue - rightValue);
                case ExpressionType.Multiply:
                    return Expression.Constant(leftValue * rightValue);
                case ExpressionType.Divide:
                    return Expression.Constant(leftValue / rightValue);
                default:
                    throw new NotImplementedException();
                }
            }
            switch (node.NodeType)
            {
            case ExpressionType.Add:
                if (IsZero(left))
                    return right;
                if (IsZero(right))
                    return left;
                break;
            case ExpressionType.Subtract:
                if (IsZero(left))
                    return Expression.Negate(right);
                if (IsZero(right))
                    return left;
                break;
            case ExpressionType.Multiply:
                if (IsZero(left) || IsZero(right))
                    return MathExpressions.Zero;
                if (IsOne(left))
                    return right;
                if (IsOne(right))
                    return left;
                break;
            case ExpressionType.Divide:
                if (IsZero(right))
                    throw new DivideByZeroException();
                if (IsZero(left))
                    return MathExpressions.Zero;
                if (IsOne(right))
                    return left;
                break;
            default:
                throw new NotImplementedException();
            }
            return Expression.MakeBinary(node.NodeType, left, right);
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            var operand = Visit(node.Operand);
            ConstantExpression operandConstant = operand as ConstantExpression;
            if (operandConstant != null && (operandConstant.Value is double))
            {
                double operandValue = (double)operandConstant.Value;
                switch (node.NodeType)
                {
                case ExpressionType.Negate:
                    if (operandValue == 0.0)
                        return MathExpressions.Zero;
                    return Expression.Constant(-operandValue);
                default:
                    throw new NotImplementedException();
                }
            }
            switch (node.NodeType)
            {
            case ExpressionType.Negate:
                if (operand.NodeType == ExpressionType.Negate)
                {
                    return ((UnaryExpression)operand).Operand;
                }
                break;
            default:
                throw new NotImplementedException();
            }
            return Expression.MakeUnary(node.NodeType, operand, node.Type);
        }
        private static bool IsZero(Expression expression)
        {
            ConstantExpression constant = expression as ConstantExpression;
            if (constant != null)
            {
                if (constant.Value.Equals(0.0))
                    return true;
            }
            return false;
        }
        private static bool IsOne(Expression expression)
        {
            ConstantExpression constant = expression as ConstantExpression;
            if (constant != null)
            {
                if (constant.Value.Equals(1.0))
                    return true;
            }
            return false;
        }
    }
