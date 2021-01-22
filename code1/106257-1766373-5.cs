    protected virtual void OnPropertyValidated(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
    {
        IDataErrorInfo model = bindingContext.Model as IDataErrorInfo;
        if (model != null)
        {
            string str = model[propertyDescriptor.Name];
            if (!string.IsNullOrEmpty(str))
            {
                string key = CreateSubPropertyName(bindingContext.ModelName, propertyDescriptor.Name);
                bindingContext.ModelState.AddModelError(key, str);
            }
        }
    }
