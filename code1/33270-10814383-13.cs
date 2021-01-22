    public static class PropertyChangedExtensions
    {
        public static void Raise<TProperty>(
            this PropertyChangedEventHandler handler, Expression<Func<TProperty>> property)
        {
            if (handler == null)
                return;
            var memberExpr = (MemberExpression)property.Body;
            var propertyName = memberExpr.Member.Name;
            var sender = ((ConstantExpression)memberExpr.Expression).Value;
            handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
        public static PropertyChangedEventHandler SubscribeToPropertyChanged<T, TProperty>(
            this T obj, Expression<Func<T, TProperty>> property, Action<T> handler)
            where T : INotifyPropertyChanged
        {
            if (handler == null)
                return null;
            var memberExpr = (MemberExpression)property.Body;
            var propertyName = memberExpr.Member.Name;
            PropertyChangedEventHandler subscription = (sender, eventArgs) =>
            {
                if (propertyName == eventArgs.PropertyName)
                    handler(obj);
            };
            obj.PropertyChanged += subscription;
            return subscription;
        }
    }
