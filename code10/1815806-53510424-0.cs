    // ***
    // *** Expression Extensions
    // ***
    public static Expression Swap(this Expression orig, Expression from, Expression to) => new SwapVisitor(from, to).Visit(orig);
    /// <summary>
    /// Standard ExpressionVisitor to swap two Expressions in an Expression.
    /// </summary>
    public class SwapVisitor : ExpressionVisitor {
        public readonly Expression from;
        public readonly Expression to;
    
        public SwapVisitor(Expression _from, Expression _to) {
            from = _from;
            to = _to;
        }
    
        public override Expression Visit(Expression node) => node == from ? to : base.Visit(node);
    }
