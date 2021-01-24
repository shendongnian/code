	public class GetXmlElementName<T>
	{
		public static string From<TProperty>(Expression<Func<T, TProperty>> expression)
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
