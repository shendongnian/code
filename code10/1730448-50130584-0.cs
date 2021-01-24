    private static IEnumerable<PropertyInfo> GetPropertiesByStepName<TModel>(TModel model, string name)
    {
        // Get the properties where there is a StepAttribute and the name is set to the `name` parameter
        var properties = model.GetType()
            .GetProperties()
            .Where(x =>
    			x.GetCustomAttribute<StepAttribute>() != null &&
    			x.GetCustomAttribute<StepAttribute>().Name == name);
    
        return properties;
    }
