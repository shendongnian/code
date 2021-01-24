    public class SanitizeModelBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            bool sanitize = controllerContext.HttpContext.Request.HttpMethod == "POST";
            //get value from default binder
            object value = base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
            if (!sanitize)
            {
                return value;
            }
            //sanitize value if it is a string
            string stringValue = value as string;
            if (stringValue != null)
            {
                return stringValue.SanitizeString();
            }
            return value;
        }
    }
