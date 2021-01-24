    void SetField(string fieldName)
    {
        if (changesDictionary.TryGetValue(fieldName, out string fieldValue))
        {
            PropertyInfo propertyInfo = resultObject.GetType().GetProperty(fieldName);
            propertyInfo.SetValue(resultObject, fieldValue);
        }
    }
    SetField("field1");
    SetField("field2");
    SetField("field3");
