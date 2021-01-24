    public static object GetValue(object instance, string path)
    {
        object currentObject = instance;
        foreach (string propertyName in path.Split('/'))
        {
            currentObject = currentObject
                .GetType()
                .GetProperty(propertyName)
                .GetValue(currentObject, null);
        }
        return currentObject;
    }
