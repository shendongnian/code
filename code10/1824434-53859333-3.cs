    public static class ExpressionExt {
        public static TE AddTestForNull<TE>(this TE orig) where TE : Expression => (TE)(new NullTestVisitor().Visit(orig));
    }
    
    /// <summary>
    /// ExpressionVisitor to replace a obj.member Expression with a null test ((obj == null) ? null : obj.member)
    /// </summary>
    public class NullTestVisitor : System.Linq.Expressions.ExpressionVisitor {
        public override Expression Visit(Expression node) {
            if (node is MemberExpression nme)
                return Expression.Condition(Expression.MakeBinary(ExpressionType.Equal, nme.Expression.AddTestForNull(), Expression.Constant(null, nme.Expression.Type)),
                                            Expression.Constant(null, nme.Type),
                                            nme);
            else
                return base.Visit(node);
        }
    }
