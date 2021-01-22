    namespace MyApp.Web.Mvc
    {
	    public class DefaultModelBinder : System.Web.Mvc.DefaultModelBinder
	    {
	        protected override void BindProperty(
	            ControllerContext controllerContext, 
	            ModelBindingContext bindingContext, 
	            PropertyDescriptor propertyDescriptor)
	        {
	            var propertyBinderAttribute = TryFindPropertyBinderAttribute(propertyDescriptor);
	            if (propertyBinderAttribute != null)
	            {
	                var binder = CreateBinder(propertyBinderAttribute);
	                var value = binder.BindModel(controllerContext, bindingContext, propertyDescriptor);
	                propertyDescriptor.SetValue(bindingContext.Model, value);
	            }
	            else // revert to the default behavior.
	            {
	                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
	            }
	        }
	        IPropertyBinder CreateBinder(PropertyBinderAttribute propertyBinderAttribute)
	        {
	            return (IPropertyBinder)DependencyResolver.Current.GetService(propertyBinderAttribute.BinderType);
	        }
	        PropertyBinderAttribute TryFindPropertyBinderAttribute(PropertyDescriptor propertyDescriptor)
	        {
	            return propertyDescriptor.Attributes
	              .OfType<PropertyBinderAttribute>()
	              .FirstOrDefault();
	        }
	    }
    }
