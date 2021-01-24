    public BaseClass CreateCopy()
    {
        var type = GetType();
        var result = Activator.CreateInstance(type);
        foreach (var propertyInfo in type.GetProperties())
        {
            var skipThisProperty = !propertyInfo.GetCustomAttributes(
                    typeof(CopiablePropertyAttribute), false)
                .Any();
            if (skipThisProperty)
                continue;
            var value = propertyInfo.GetValue(this, null);
            propertyInfo.SetValue(result, value, null);
        }
        return (BaseClass) result;
    }
    
