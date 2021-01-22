    public static class DynamicObjects
    {
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, Action<object, object>>> _setters
            = new ConcurrentDictionary<Type, ConcurrentDictionary<string, Action<object, object>>>();
        public static void SetProperty(object instance, string property, object value)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (property == null)
                throw new ArgumentNullException("property");
            if (property.Length == 0)
                throw new ArgumentException("The property name cannot be empty.", "property");
            Type type = instance.GetType();
            var settersForType = _setters.GetOrAdd(type, CreateDictionaryForType);
            var setter = settersForType.GetOrAdd(property, (obj, newValue) => CreateSetterForProperty(type, property));
            setter(instance, value);
        }
        private static ConcurrentDictionary<string, Action<object, object>> CreateDictionaryForType(Type type)
        {
            return new ConcurrentDictionary<string, Action<object, object>>();
        }
        private static Action<object, object> CreateSetterForProperty(Type type, string property)
        {
            var propertyInfo = type.GetProperty(property);
            if (propertyInfo == null)
                return (o, v) => ThrowInvalidPropertyException(type, property);
            var setterMethod = propertyInfo.GetSetMethod();
            if (setterMethod == null)
                return (o, v) => ThrowReadOnlyPropertyException(type, property);
            ParameterExpression instance = Expression.Parameter(typeof(object), "instance");
            ParameterExpression value = Expression.Parameter(typeof(object), "value");
            Expression<Action<object, object>> expression =
                Expression.Lambda<Action<object, object>>(
                Expression.Call(instance, setterMethod, Expression.Convert(value, propertyInfo.PropertyType)),
                instance,
                value);
            return expression.Compile();
        }
        private static void ThrowInvalidPropertyException(Type type, string propertyName)
        {
            throw new InvalidOperationException("The type '" + type.FullName + "' does not have a publicly accessible property '" + propertyName + "'.");
        }
        private static void ThrowReadOnlyPropertyException(Type type, string propertyName)
        {
            throw new InvalidOperationException("The type '" + type.FullName + "' does not have a publicly visible setter for the '" + propertyName + "' property.");
        }
    }
