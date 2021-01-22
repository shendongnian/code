    // This class implements a custom data type for data binding.
    public class TimeInterval
    {
        double _value;
        public TimeInterval(string value)
        {
            _value = value.ToSeconds();
        }
        public TimeInterval(double value)
        {
            _value = value;
        }
        public string GetText()
        {
            return _value.ToTimeString();
        }
        public double? GetValue()
        {
            return _value;
        }
    }
    // This class implements custom binding for the TimeInterval custom type.  
    // It is registered in Global.asax 
    public class TimeIntervalBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string value = GetAttemptedValue(bindingContext);
            if (value == "")
                return null;
            return new TimeInterval(value);
        }
        private static string GetAttemptedValue(ModelBindingContext context)
        {
            ValueProviderResult value = context.ValueProvider[context.ModelName];
            return value.AttemptedValue ?? string.Empty;
        }
    }
    // in Global.asax:
    protected void Application_Start()
    {
        RegisterRoutes(RouteTable.Routes);
        ModelBinders.Binders.Add(typeof(TimeInterval), new TimeIntervalBinder());
    }
