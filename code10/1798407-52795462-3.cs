    private static bool Validate(object model)
    {
        foreach (var propertyInfo in model.GetType().GetProperties())
        {                
            foreach (var attribute in propertyInfo.GetCustomAttributes(true))
            {
                var notNullAttribute = attribute as NotNullAttribute;
                if (notNullAttribute != null)
                {
                    if (!notNullAttribute.IsValid(propertyInfo.GetValue(model)))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
