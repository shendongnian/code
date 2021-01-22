    public class CustomModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);            
            model = ResolveKeyValuePairs(bindingContext, model);
            return model;
        }
        private object ResolveKeyValuePairs(ModelBindingContext bindingContext, object model)
        {
            var type = bindingContext.ModelType;
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof (KeyValuePair<,>))
                {                    
                    var values = bindingContext.ValueProvider as ValueProviderCollection;
                    if (values != null)
                    {
                        var key = values.GetValue(bindingContext.ModelName + ".Key");
                        var keyValue = Convert.ChangeType(key.AttemptedValue, bindingContext.ModelType.GetGenericArguments()[0]);
                        var value = values.GetValue(bindingContext.ModelName + ".Value");
                        var valueValue = Convert.ChangeType(value.AttemptedValue, bindingContext.ModelType.GetGenericArguments()[1]);
                        return Activator.CreateInstance(bindingContext.ModelType, new[] {keyValue, valueValue});
                    }
                    
                }
            }
            return model;
        }
