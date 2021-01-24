	public class ParameterReplacerVisitor<T> : ExpressionVisitor
	{
		private string parameterName;
		private Expression parameterValue;
	
		public ParameterReplacerVisitor(string name, T value)
		{
			this.parameterName = name;
			// transform value to expression
			this.parameterValue = Expression.Constant(value);
		}
		
		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			// create new lambda expression without the replaced parameter
			return Expression.Lambda(Visit(node.Body), node.Parameters.Where(x => x.Name != parameterName).ToArray());
		}
	
		protected override Expression VisitParameter(ParameterExpression node)
		{
			// if we find our parameter by name replace its usage by the constant expression
			return node.Name == parameterName ? parameterValue : node;
		}
	}
