      internal class DebugDisplayTree : ExpressionVisitor
      {
        private int indentLevel = 0;
        
        protected override System.Linq.Expressions.Expression Visit(Expression exp)
        {
          if (exp != null)
          {
            Trace.WriteLine(string.Format("{0} : {1} ", exp.NodeType, exp.GetType().ToString()).PrependIndent(indentLevel));
          }
          indentLevel++;
          Expression result = base.Visit(exp);
          indentLevel--;
          return result;
        }
        ...
