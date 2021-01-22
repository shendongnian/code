	class Test
	{
		public Test()
		{
			Expression<Func<string, string>> trim2 = s => s.Substring(1).Substring(1);
			var modifier = new PopModifier();
			Expression<Func<string, string>> trim1 = (Expression<Func<string, string>>)modifier.Modify(trim2);
			var test2 = trim2.Compile();
			var test1 = trim1.Compile();
			var input = "abc";
			if (test2(input) != "c")
			{
				throw new Exception();
			}
			if (test1(input) != "bc")
			{
				throw new Exception();
			}			
		}
	}
	public class PopModifier : ExpressionVisitor
	{
		bool didModify = false;
		public Expression Modify(Expression expression)
		{
			return Visit(expression);
		}
		protected override Expression VisitMethodCall(MethodCallExpression m)
		{
			if (!didModify)
			{
				didModify = true;
				return m.Object;
			}
			return base.VisitMethodCall(m);
		}
	}
