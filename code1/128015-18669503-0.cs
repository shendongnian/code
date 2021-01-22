	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	namespace ConsoleApplication3
	{
		class Program
		{
			static void Main(string[] args)
			{
				var combined = TryCombiningExpressions(c => c.FirstName == "Dog", c => c.LastName == "Boy");
			
				Console.WriteLine("Dog Boy should be true: {0}", combined(new FullName { FirstName = "Dog", LastName = "Boy" }));
				Console.WriteLine("Cat Boy should be false: {0}", combined(new FullName { FirstName = "Cat", LastName = "Boy" }));
				Console.ReadLine();
			}
			public class FullName
			{
				public string FirstName { get; set; }
				public string LastName { get; set; }
			}
			public static Func<FullName, bool> TryCombiningExpressions(Expression<Func<FullName, bool>> func1, Expression<Func<FullName, bool>> func2)
			{
				return func1.CombineWithAndAlso(func2).Compile();
			}
		}
		public static class CombineExpressions
		{
			public static Expression<Func<TInput, bool>> CombineWithAndAlso<TInput>(this Expression<Func<TInput, bool>> func1, Expression<Func<TInput, bool>> func2)
			{
				return Expression.Lambda<Func<TInput, bool>>(
					Expression.AndAlso(
						func1.Body, new ExpressionParameterReplacer(func2.Parameters, func1.Parameters).Visit(func2.Body)),
					func1.Parameters);
			}
			public static Expression<Func<TInput, bool>> CombineWithOrElse<TInput>(this Expression<Func<TInput, bool>> func1, Expression<Func<TInput, bool>> func2)
			{
				return Expression.Lambda<Func<TInput, bool>>(
					Expression.AndAlso(
						func1.Body, new ExpressionParameterReplacer(func2.Parameters, func1.Parameters).Visit(func2.Body)),
					func1.Parameters);
			}
			private class ExpressionParameterReplacer : ExpressionVisitor
			{
				public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
				{
					ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
					for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
						ParameterReplacements.Add(fromParameters[i], toParameters[i]);
				}
				private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements { get; set; }
				protected override Expression VisitParameter(ParameterExpression node)
				{
					ParameterExpression replacement;
					if (ParameterReplacements.TryGetValue(node, out replacement))
						node = replacement;
					return base.VisitParameter(node);
				}
			}
		}
	}
