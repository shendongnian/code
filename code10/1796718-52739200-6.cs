    public static MvcHtmlString WizardPartialFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
        Expression<Func<TModel, TProperty>> expression, string partialViewName, IWizardTransaction wizardTransaction)
    {
        var compiled = expression.Compile();
        var result = compiled.Invoke(helper.ViewData.Model);
    
        PropertyInfo currentStep = wizardTransaction.GetCurrentStepPropertyInfo();
    
        string currentStepName = currentStep.PropertyType.Name;
    
        var name = $"{currentStep.DeclaringType.Name}.{currentStepName}";
    
        var viewData = new ViewDataDictionary(helper.ViewData)
        {
            TemplateInfo = new TemplateInfo { HtmlFieldPrefix = name }
        };
    
        return helper.Partial(partialViewName, result, viewData);
    }
    public static PropertyInfo GetCurrentStepPropertyInfo(this IWizardTransaction wizardTransaction)
    {
        var properties = wizardTransaction.GetType().GetProperties()
            .Where(x => x.PropertyType.GetCustomAttributes(typeof(StepAttribute), true).Any());
    
        return properties.FirstOrDefault(x => ((StepAttribute)Attribute
            .GetCustomAttribute(x.PropertyType, typeof(StepAttribute))).Step == wizardTransaction.CurrentStep);
    }
