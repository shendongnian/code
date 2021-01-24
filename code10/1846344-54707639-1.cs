    void SetField(string fieldName)
    {
        if (changesDictionary.TryGetValue(fieldName, out string fieldValue))
        {
            var propertyInfo = resultObject.GetType().GetProperty(fieldName);
            propertyInfo.SetValue(resultObject, fieldValue);
        }
    }
