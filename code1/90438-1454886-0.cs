    Dictionary<string, object> GetCombinedProperties(object o1, object o2) {
        var combinedProperties = new Dictionary<string, object>();
        foreach (var propertyInfo in o1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            combinedProperties.Add(propertyInfo.Name, propertyInfo.GetValue(o1, null));
        foreach (var propertyInfo in o2.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            combinedProperties.Add(propertyInfo.Name, propertyInfo.GetValue(o2, null));
        return combinedProperties;
    }
