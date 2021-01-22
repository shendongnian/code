    public class PartBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.PropertyType == typeof(Owner))
            {
                var idResult = bindingContext.ValueProvider
                    .GetValue(bindingContext.ModelName + ".Id");
                if (idResult == null || string.IsNullOrEmpty(idResult.AttemptedValue))
                {
                    return null;
                }
            }
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
