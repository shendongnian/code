    public static void SomeGenericFunc<T, PT>(T classObject, Expression<Func<T, PT>> expression)
    {
            var targetType = typeof(T);
            var property = expression.Body as MemberExpression;
            var propertyInfo = property?.Member as PropertyInfo;
            if (property == null || propertyInfo == null)
                throw new ArgumentException("Expecting property!");
            if (propertyInfo.ReflectedType != targetType)
                throw new ArgumentException($"Property does not belong to type {targetType.Name}");
            string propertyName = propertyInfo.Name;
    }
