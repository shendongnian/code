        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
        {
            Check.RequireNotNull<object>(propertyExpression, "propertyExpression");
            switch (propertyExpression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (propertyExpression.Body as MemberExpression).Member.Name;
                case ExpressionType.Convert:
                    return ((propertyExpression.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
            }
            var msg = string.Format("Expression NodeType: '{0}' does not refer to a property and is therefore not supported", 
                propertyExpression.Body.NodeType);
            Check.Require(false, msg);
            throw new InvalidOperationException(msg);
        }
