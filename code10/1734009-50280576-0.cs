    private static Func<T, TProperty, PropertyValidatorContext, bool> MustWhenChangedPredicate<T, TProperty>(Func<T, TProperty, PropertyValidatorContext, bool> predicate)
    {
        return (t, p, context) =>
        {
            var instance = (IChangeTrackingObject)context.Instance;
            //The type name always prefixes the property
            var propertyName = context.PropertyName.Split(new[] { '.' }, 2).Skip(1).First();
            if (false == instance.GetChangedProperties().ContainsKey(propertyName))
            {
                return true;
            }
            var oldValue = instance.GetChangedProperties().Get(propertyName).OldValue;
            var newValue = context.PropertyValue;
            if (oldValue == null && newValue == null)
            {
                return true;
            }
            if ((oldValue != null && oldValue.Equals(newValue)) ||
                   (newValue != null && newValue.Equals(oldValue)))
            {
                return true;
            }
            return predicate(t, p, context);
        };
    }
