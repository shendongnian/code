    public static class ExpressionExt {
        /// <summary>
        /// Replaces an Expression (reference Equals) with another Expression
        /// </summary>
        /// <param name="orig">The original Expression.</param>
        /// <param name="from">The from Expression.</param>
        /// <param name="to">The to Expression.</param>
        /// <returns>Expression with all occurrences of from replaced with to</returns>
        public static Expression Replace(this Expression orig, Expression from, Expression to) => new ReplaceVisitor(from, to).Visit(orig);
    
        public static bool EqualsByShallowValue(this Expression a, Expression b) {
            if (ReferenceEquals(a, b))
                return true;
            else if (a == null || b == null)
                return false;
            else if (a.NodeType != b.NodeType || a.Type != b.Type)
                return false;
    
            switch (a.NodeType) {
                case ExpressionType.Constant:
                    return (a as ConstantExpression).Value.Equals((b as ConstantExpression).Value);
                case ExpressionType.MemberAccess:
                    var ae = a as MemberExpression;
                    var be = b as MemberExpression;
                    return ae.Expression == be.Expression && ae.Member == be.Member;
                default:
                    return false;
            }
        }
    
        /// <summary>
        /// Replaces an Expression (EqualsByShallowValue) with another Expression
        /// </summary>
        /// <param name="orig">The original Expression.</param>
        /// <param name="from">The from Expression.</param>
        /// <param name="to">The to Expression.</param>
        /// <returns>Expression with all occurrences of from replaced with to</returns>
        public static Expression ReplaceByValue(this Expression orig, Expression from, Expression to) => new ReplaceVisitorByValue(from, to).Visit(orig);    
    }
