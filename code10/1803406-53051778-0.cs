    public static class Extensions
    {
        private class ReferencedPropertyFinder : ExpressionVisitor
        {
            private readonly Type _ownerType;
            private readonly List<PropertyInfo> _properties = new List<PropertyInfo>();
            private Expression _parameterExpression;
            private int _currentPosition = 0;
            public ReferencedPropertyFinder(Type ownerType)
            {
                _ownerType = ownerType;
            }
            public IReadOnlyList<PropertyInfo> Properties
            {
                get { return _properties; }
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                var propertyInfo = node.Member as PropertyInfo;
                if (propertyInfo != null) {
                    var currentParameter = GetParameter(node);
                    if (_parameterExpression == currentParameter) {
                        _properties.Insert(_currentPosition, propertyInfo);
                    } else {
                        _properties.Add(propertyInfo);
                        _parameterExpression = currentParameter;
                        _currentPosition = _properties.Count() - 1;
                    }
                }
                return base.VisitMember(node);
            }
            private ParameterExpression GetParameter(MemberExpression node)
            {
                if (node.Expression is ParameterExpression) {
                    return (ParameterExpression)node.Expression;
                } else {
                    return GetParameter((MemberExpression)node.Expression);
                }
            }
        }
        private static IReadOnlyList<PropertyInfo> GetReferencedProperties<T, U>(this Expression<Func<T, U>> expression)
        {
            var v = new ReferencedPropertyFinder(typeof(T));
            v.Visit(expression);
            return v.Properties;
        }
        public static string ToPropertyPath<T>(this Expression<Func<T, object>> expression)
        {
            var properties = expression.GetReferencedProperties();
            var path = string.Join(".", properties.Select(x => x.Name));
            return path;
        }
    }
