	public class ParameterReplacerVisitor : ExpressionVisitor
	{
		private string parameterName;
		private Expression parameterReplacement;
	
		public static ParameterReplacerVisitor Create<T>(string name, T value)
		{
			return new ParameterReplacerVisitor(name, Expression.Constant(value));
		}
		public ParameterReplacerVisitor(string name, Expression replacement)
		{
			this.parameterName = name;
			this.parameterReplacement = replacement;
		}
			
		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			// create new lambda expression without the replaced parameter
			return Expression.Lambda(Visit(node.Body), node.Parameters.Where(x => x.Name != parameterName).ToArray());
		}
	
		protected override Expression VisitParameter(ParameterExpression node)
		{
			// if we find our parameter by name replace its usage by the constant expression
			return node.Name == parameterName ? parameterReplacement : node;
		}
	}
