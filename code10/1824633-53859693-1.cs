    /// <summary>
    /// Standard ExpressionVisitor to replace an Expression with another in an Expression.
    /// </summary>
    public class ReplaceVisitor : ExpressionVisitor {
        readonly Expression from;
        readonly Expression to;
    
        public ReplaceVisitor(Expression from, Expression to) {
            this.from = from;
            this.to = to;
        }
    
        public override Expression Visit(Expression node) => node == from ? to : base.Visit(node);
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
