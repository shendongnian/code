    public sealed class ExpressionWriterVisitor : ExpressionVisitor
    {
      private TextWriter _writer;
      public ExpressionWriterVisitor(TextWriter writer)
      {
        _writer = writer;
      }
      protected override Expression VisitParameter(ParameterExpression node)
      {
        _writer.Write(node.Name);
        return node;
      }
      protected override Expression VisitLambda<T>(Expression<T> node)
      {
        _writer.Write('(');
        _writer.Write(string.Join(',', node.Parameters.Select(param => param.Name)));
        _writer.Write(')');
        _writer.Write("=>");
        Visit(node.Body);
        return node;
      }
      protected override Expression VisitConditional(ConditionalExpression node)
      {
        Visit(node.Test);
        _writer.Write('?');
        Visit(node.IfTrue);
        _writer.Write(':');
        Visit(node.IfFalse);
        return node;
      }
      protected override Expression VisitBinary(BinaryExpression node)
      {
        Visit(node.Left);
        _writer.Write(GetOperator(node.NodeType));
        Visit(node.Right);
        return node;
      }
      protected override Expression VisitMember(MemberExpression node)
      {
        _writer.Write(node.Member.Name);
        return node;
      }
      protected override Expression VisitConstant(ConstantExpression node)
      {
        if (node.Type == typeof(string))
        {
          _writer.Write('"');
          _writer.Write(node.Value);
          _writer.Write('"');
        }
        else
        {
          _writer.Write(node.Value);
        }
        return node;
      }
      private static string GetOperator(ExpressionType type)
      {
        switch (type)
        {
          case ExpressionType.Equal:
            return "==";
          case ExpressionType.Not:
            return "!";
          case ExpressionType.NotEqual:
            return "!==";
          case ExpressionType.GreaterThan:
            return ">";
          case ExpressionType.GreaterThanOrEqual:
            return ">=";
          case ExpressionType.LessThan:
            return "<";
          case ExpressionType.LessThanOrEqual:
            return "<=";
          case ExpressionType.Or:
            return "|";
          case ExpressionType.OrElse:
            return "||";
          case ExpressionType.And:
            return "&";
          case ExpressionType.AndAlso:
            return "&&";
          case ExpressionType.Add:
            return "+";
          case ExpressionType.AddAssign:
            return "+=";
          case ExpressionType.Subtract:
            return "-";
          case ExpressionType.SubtractAssign:
            return "-=";
          default:
            return "???";
        }
      }
