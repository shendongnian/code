    public static class PropertyChangedExtensions
    {
        public static void Raise(this PropertyChangedEventHandler handler, Expression<Func<object>> property)
        {
            if (handler == null)
                return;
            var memberExpr = (MemberExpression)property.Body;
            var propertyName = memberExpr.Member.Name;
            var sender = ((ConstantExpression)memberExpr.Expression).Value;
            handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
