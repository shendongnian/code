    public static class PropertyChangedExtensions
    {
        public static void Raise(this PropertyChangedEventHandler handler, Expression<Func<object>> property)
        {
            if (handler == null)
                return;
            var boxingExpr = property.Body as UnaryExpression;
            var memberExpr = (MemberExpression)(boxingExpr == null ? 
                property.Body : boxingExpr.Operand);
            var propertyName = memberExpr.Member.Name;
            var sender = ((ConstantExpression)memberExpr.Expression).Value;
            handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
