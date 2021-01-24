    public static class ExpressionExt {
        public static Expression PropagateNull(this Expression orig) => new NullVisitor().Visit(orig);
    }
    
    /// <summary>
    /// ExpressionVisitor to replace a null.member Expression with a null
    /// </summary>
    public class NullVisitor : System.Linq.Expressions.ExpressionVisitor {
        public override Expression Visit(Expression node) {
            if (node is MemberExpression nme && nme.Expression is ConstantExpression nce && nce.Value == null)
                return Expression.Constant(null, nce.Type.GetMember(nme.Member.Name).Single().GetMemberType());
            else
                return base.Visit(node);
        }
    }
