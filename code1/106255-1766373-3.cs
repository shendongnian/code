    protected virtual void OnPropertyValidated(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
    {
        ModelMetadata metadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
        metadata.Model = value;
        string prefix = CreateSubPropertyName(bindingContext.ModelName, metadata.PropertyName);
        foreach (ModelValidator validator in metadata.GetValidators(controllerContext))
        {
            foreach (ModelValidationResult result in validator.Validate(bindingContext.Model))
            {
                bindingContext.ModelState.AddModelError(CreateSubPropertyName(prefix, result.MemberName), result.Message);
            }
        }
        if ((bindingContext.ModelState.IsValidField(prefix) && (value == null)) && !TypeHelpers.TypeAllowsNullValue(propertyDescriptor.PropertyType))
        {
            bindingContext.ModelState.AddModelError(prefix, GetValueRequiredResource(controllerContext));
        }
    }
