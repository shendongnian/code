	public static class Extensions
	{
		public static string GetXmlElementName<T, TProperty>(this T obj, Expression<Func<T, TProperty>> expression)
		{
			var memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
				return string.Empty;
			var xmlElementAttribute = memberExpression.Member.GetCustomAttribute<XmlElementAttribute>();
			if (xmlElementAttribute == null)
				return string.Empty;
			return xmlElementAttribute.ElementName;
		}
	}
