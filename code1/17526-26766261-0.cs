    public class PropertyMapper<T>
	{
		public virtual PropertyInfo PropertyInfo<U>(Expression<Func<T, U>> expression)
		{
			var member = expression.Body as MemberExpression;
			if (member != null && member.Member is PropertyInfo)
				return member.Member as PropertyInfo;
			throw new ArgumentException("Expression is not a Property", "expression");
		}
		public virtual string PropertyName<U>(Expression<Func<T, U>> expression)
		{
			return PropertyInfo<U>(expression).Name;
		}
		public virtual Type PropertyType<U>(Expression<Func<T, U>> expression)
		{
			return PropertyInfo<U>(expression).PropertyType;
		}
	}
