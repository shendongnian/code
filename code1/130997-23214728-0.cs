	public static Expression<Func<T, bool>> ToExpression<T>(string andOrOperator, string propName, string opr, string value, Expression<Func<T, bool>> expr = null)
		{
			Expression<Func<T, bool>> func = null;
			try
			{
				ParameterExpression paramExpr = Expression.Parameter(typeof(T));
				var arrProp = propName.Split('.').ToList();
				Expression binExpr = null;
				string partName = string.Empty;
				arrProp.ForEach(x =>
				{
					Expression tempExpr = null;
					partName = partName.IsNull() ? x : partName + "." + x;
					if (partName == propName)
					{
						var member = NestedExprProp(paramExpr, partName);
						var type = member.Type.Name == "Nullable`1" ? Nullable.GetUnderlyingType(member.Type) : member.Type;
						tempExpr = ApplyFilter(opr, member, Expression.Convert(ToExprConstant(type, value), member.Type));
					}
					else
						tempExpr = ApplyFilter("!=", NestedExprProp(paramExpr, partName), Expression.Constant(null));
					if (binExpr != null)
						binExpr = Expression.AndAlso(binExpr, tempExpr);
					else
						binExpr = tempExpr;
				});
				Expression<Func<T, bool>> innerExpr = Expression.Lambda<Func<T, bool>>(binExpr, paramExpr);
				if (expr != null)
					innerExpr = (andOrOperator.IsNull() || andOrOperator == "And" || andOrOperator == "AND" || andOrOperator == "&&") ? innerExpr.And(expr) : innerExpr.Or(expr);
				func = innerExpr;
			}
			catch { }
			return func;
		}
		private static MemberExpression NestedExprProp(Expression expr, string propName)
		{
			string[] arrProp = propName.Split('.');
			int arrPropCount = arrProp.Length;
			return (arrPropCount > 1) ? Expression.Property(NestedExprProp(expr, arrProp.Take(arrPropCount - 1).Aggregate((a, i) => a + "." + i)), arrProp[arrPropCount - 1]) : Expression.Property(expr, propName);
		}
		private static Expression ToExprConstant(Type prop, string value)
		{
			if (value.IsNull())
				return Expression.Constant(value);
			object val = null;
			switch (prop.FullName)
			{
				case "System.Guid":
					val = value.ToGuid();
					break;
				default:
					val = Convert.ChangeType(value, Type.GetType(prop.FullName));
					break;
			}
			return Expression.Constant(val);
		}
		private static Expression ApplyFilter(string opr, Expression left, Expression right)
		{
			Expression InnerLambda = null;
			switch (opr)
			{
				case "==":
				case "=":
					InnerLambda = Expression.Equal(left, right);
					break;
				case "<":
					InnerLambda = Expression.LessThan(left, right);
					break;
				case ">":
					InnerLambda = Expression.GreaterThan(left, right);
					break;
				case ">=":
					InnerLambda = Expression.GreaterThanOrEqual(left, right);
					break;
				case "<=":
					InnerLambda = Expression.LessThanOrEqual(left, right);
					break;
				case "!=":
					InnerLambda = Expression.NotEqual(left, right);
					break;
				case "&&":
					InnerLambda = Expression.And(left, right);
					break;
				case "||":
					InnerLambda = Expression.Or(left, right);
					break;
				case "LIKE":
					InnerLambda = Expression.Call(left, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), right);
					break;
				case "NOTLIKE":
					InnerLambda = Expression.Not(Expression.Call(left, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), right));
					break;
			}
			return InnerLambda;
		}
		public static Expression<Func<T, object>> PropExpr<T>(string PropName)
		{
			ParameterExpression paramExpr = Expression.Parameter(typeof(T));
			var tempExpr = Extentions.NestedExprProp(paramExpr, PropName);
			return Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Lambda(tempExpr, paramExpr).Body, typeof(object)), paramExpr);
		}
		public static IQueryOver<T, T> OrderBy<T>(this IQueryOver<T, T> Collection, string sidx, string sord)
		{
			return sord == "asc" ? Collection.OrderBy(NHibernate.Criterion.Projections.Property(sidx)).Asc : Collection.OrderBy(NHibernate.Criterion.Projections.Property(sidx)).Desc;
		}
		public static Expression<Func<T, TResult>> And<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
		{
			var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, TResult>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
		}
		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
		}
