    public class TemperatureModelBinder : IPropertyBinder
    {
        public object BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {            
            var propertyValue = controllerContext.HttpContext.Request.Form[propertyDescriptor.Name];
            double.TryParse(propertyValue, out var result);
            
            return UnitsNet.Temperature.FromDegreesFahrenheit(result);
        }
    }
    public interface IPropertyBinder
    {
        object BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor);
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyBinderAttribute : Attribute
    {
        public Type BinderType { get; private set; }
        public PropertyBinderAttribute(Type binderType)
        {
            BinderType = binderType;
        }
        public IPropertyBinder GetBinder()
        {
            return (IPropertyBinder)DependencyResolver.Current.GetService(BinderType);
        }
    }
    public class ModelBinderBase : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            PropertyBinderAttribute attribute = propertyDescriptor.Attributes
                .OfType<PropertyBinderAttribute>()
                .SingleOrDefault();
            if (attribute == null)
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
            else
            {
                propertyDescriptor.SetValue(bindingContext.Model, attribute.GetBinder().BindProperty(controllerContext, bindingContext, propertyDescriptor));
            }
        }
    }
