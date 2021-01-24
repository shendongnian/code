    /// <summary>
    /// ExpressionVisitor to replace an Expression (that is Equals) with another Expression.
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
    /// ExpressionVisitor to replace an Expression (with shallow matching values) with another Expression.
    /// </summary>
    public class ReplaceVisitorByValue : ExpressionVisitor {
        readonly Expression from;
        readonly Expression to;
    
        public ReplaceVisitorByValue(Expression from, Expression to) {
            this.from = from;
            this.to = to;
        }
    
        public override Expression Visit(Expression node) => node.EqualsByShallowValue(from) ? to : base.Visit(node);
    }
