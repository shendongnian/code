    public static class ExpressionExt {
        // Compose: f.Compose(g) => x => f(g(x))
        /// <summary>
        /// Composes two LambdaExpression into a new LambdaExpression: f.Compose(g) => x => f(g(x))
        /// </summary>
        /// <param name="fFn">The outer LambdaExpression.</param>
        /// <param name="gFn">The inner LambdaExpression.</param>
        /// <returns>LambdaExpression representing outer composed with inner</returns>
        public static Expression<Func<T, TResult>> Compose<T, TIntermediate, TResult>(this Expression<Func<TIntermediate, TResult>> fFn, Expression<Func<T, TIntermediate>> gFn) =>
            Expression.Lambda<Func<T, TResult>>(fFn.Body.Replace(fFn.Parameters[0], gFn.Body), gFn.Parameters[0]);    
    
        /// <summary>
        /// Replaces a sub-Expression with another Expression inside an Expression
        /// </summary>
        /// <param name="orig">The original Expression.</param>
        /// <param name="from">The from Expression.</param>
        /// <param name="to">The to Expression.</param>
        /// <returns>Expression with all occurrences of from replaced with to</returns>
        public static Expression Replace(this Expression orig, Expression from, Expression to) => new ReplaceVisitor(from, to).Visit(orig);
    }
    
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
