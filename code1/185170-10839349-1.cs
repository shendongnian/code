    public static void SetCastedValue<T>(this PropertyInfo property, T instance, object value)
    {
        if (property.DeclaringType != typeof(T))
        {
            throw new ArgumentException("property's declaring type must be equal to typeof(T).");
        }
    
        var constructedMethod = typeof (ObjectExtensions)
            .GetMethod("TryCast")
            .MakeGenericMethod(property.PropertyType);
        object valueToSet = null;
        var parameters = new[] {value, null};
        var tryCastSucceeded = Convert.ToBoolean(constructedMethod.Invoke(null, parameters));
        if (tryCastSucceeded)
        {
            valueToSet = parameters[1];
        }
    
        if (!property.CanAssignValue(valueToSet))
        {
            return;
        }
        property.SetValue(instance, valueToSet, null);
    }
