    public static class ExpressionExt {
        /// <summary>
        /// Replaces a sub-Expression with another Expression inside an Expression
        /// </summary>
        /// <param name="orig">The original Expression.</param>
        /// <param name="from">The from Expression.</param>
        /// <param name="to">The to Expression.</param>
        /// <returns>Expression with all occurrences of from replaced with to</returns>
        public static Expression Replace(this Expression orig, Expression from, Expression to) => new ReplaceVisitor(from, to).Visit(orig);
    
        public static Expression PropagateNull(this Expression orig) => new NullVisitor().Visit(orig);
    
        public static Expression Apply(this LambdaExpression e, params Expression[] args) {
            var b = e.Body;
    
            foreach (var pa in e.Parameters.Zip(args, (p, a) => (p, a)))
                b = b.Replace(pa.p, pa.a);
    
            return b.PropagateNull();
        }
    }
