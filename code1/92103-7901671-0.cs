    public void GenericMapField(object targetObj, string fieldName, object fieldValue)
    {
        PropertyInfo prop = targetObj.GetType().GetProperty(fieldName);
        if (prop != null)
        {
            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                dynamic objValue = System.Activator.CreateInstance(prop.PropertyType);
                objValue = fieldValue;
                prop.SetValue(targetObj, (object)objValue, null);
            }
            else
            {
                prop.SetValue(targetObj, fieldValue, null);
            }
        }
    }
