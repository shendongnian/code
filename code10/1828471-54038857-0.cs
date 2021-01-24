	using Realms;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	namespace ReLife.Services.RealmRelated.RealmExtensions
	{
		public static class IQueryableExtensions
		{
			public static IQueryable<T> In<T>(this IQueryable<T> source, string propertyName, List<string> objList) where T : RealmObject
			{
				// technique for how to search for many matches
				// use Expression Trees to dynamically build the LINQ statement
				// see https://msdn.microsoft.com/en-us/library/mt654267.aspx
				ParameterExpression pe = Expression.Parameter(typeof(T), "p");
				// building an expression like:
				// allInts.Where (p => p.UserKey == idsToMatch[0] || p.UserKey == idsToMatch[1]...);
				Expression chainedByOr = null;
				Expression left = Expression.Property(pe, typeof(T).GetProperty(propertyName));
				foreach (var anId in objList)
				{
					// Create an expression tree that represents the expression 'p.UserKey == idsToMatch[n]'.
					Expression right = Expression.Constant(anId);
					Expression anotherEqual = Expression.Equal(left, right);
					if (chainedByOr == null)
						chainedByOr = anotherEqual;
					else
						chainedByOr = Expression.OrElse(chainedByOr, anotherEqual);
				}
				MethodCallExpression whereCallExpression = Expression.Call(
					typeof(Queryable),
					"Where",
					new Type[] { source.ElementType },
					source.Expression,
					Expression.Lambda<Func<T, bool>>(chainedByOr, new ParameterExpression[] { pe }));
				// Create an executable query from the expression tree.
				IQueryable<T> results = source.Provider.CreateQuery<T>(whereCallExpression);
				var test = results.ToList();
				return results;
			}
		}
	}
