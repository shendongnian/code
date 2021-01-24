    public static TProperty GetStepObject<TProperty>(this IWizardTransaction wizardTransaction)
        where TProperty : class
    {
        var properties = wizardTransaction.GetType().GetProperties()
            .Where(x => x.PropertyType.GetCustomAttributes(typeof(StepAttribute), true).Any());
    
        var @object = properties.FirstOrDefault(x => ((StepAttribute)Attribute
                .GetCustomAttribute(x.PropertyType, typeof(StepAttribute))).Step == wizardTransaction.CurrentStep);
    
        return @object.GetValue(wizardTransaction) as TProperty;
    }
