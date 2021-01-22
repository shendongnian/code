    public static string[] GetTypePropertyNames(object classObject,  BindingFlags bindingFlags)
    {
        if (classObject == null)
        {
            throw new ArgumentNullException(nameof(classObject));
        }
            var type = classObject.GetType();
            var propertyInfos = type.GetProperties(bindingFlags);
            return propertyInfos.Select(propertyInfo => propertyInfo.Name).ToArray();
     }
