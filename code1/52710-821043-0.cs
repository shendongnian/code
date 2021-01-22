		/// <summary>
		/// 
		/// </summary>
		/// <param name="foreignKeys"></param>
		/// <returns></returns>
		private Expression<Func<TReferencedEntity, bool>> BuildForeignKeysContainsPredicate(List<object> foreignKeys, string primaryKey)
		{
			Expression<Func<TReferencedEntity, bool>> result = default(Expression<Func<TReferencedEntity, bool>>);
			try
			{
				ParameterExpression entityParameter = Expression.Parameter(typeof(TReferencedEntity), "referencedEntity");
				ConstantExpression foreignKeysParameter = Expression.Constant(foreignKeys, typeof(List<object>));
				MemberExpression memberExpression = Expression.Property(entityParameter, primaryKey);
				Expression convertExpression = Expression.Convert(memberExpression, typeof(object));
				MethodCallExpression containsExpression = Expression.Call(foreignKeysParameter
					, "Contains", new Type[] { }, convertExpression);
				result = Expression.Lambda<Func<TReferencedEntity, bool>>(containsExpression, entityParameter);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
