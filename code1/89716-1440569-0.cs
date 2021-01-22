    case ExpressionType.Equal:
    case ExpressionType.NotEqual:
        if (right.NodeType == ExpressionType.Constant)
                    {
                        ConstantExpression ce = (ConstantExpression)right;
                        if (ce.Value == null)
                        {
                            this.Visit(left);
                            sb.Append(" IS NOT NULL");
                            break;
                        }
                    }
                    else if (left.NodeType == ExpressionType.Constant)
                    {
                        ConstantExpression ce = (ConstantExpression)left;
                        if (ce.Value == null)
                        {
                            this.Visit(right);
                            sb.Append(" IS NOT NULL");
                            break;
                        }
                    }
                    goto case ExpressionType.LessThan;
