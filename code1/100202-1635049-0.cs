    public static class Symbolic
    {
        public static Expression Expand(Expression expression)
        {
            return new ExpandVisitor().Visit(expression);
        }
        public static Expression Simplify(Expression expression)
        {
            return new SimplifyVisitor().Visit(expression);
        }
        public static Expression PartialDerivative(Expression expression, ParameterExpression parameter)
        {
            bool totalDerivative = false;
            return new DerivativeVisitor(parameter, totalDerivative).Visit(expression);
        }
        public static string ToString(Expression expression)
        {
            ConstantExpression result = (ConstantExpression)new ListPrintVisitor().Visit(expression);
            return result.Value.ToString();
        }
    }
