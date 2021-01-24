    [ModelBinder(BinderType = typeof(SomeClassBinder))]
    public class SomeClass
    {
        public decimal SomeValue { get; set; }
    }
    
    public class SomeClassBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var modelName = bindingContext.ModelName;
            
            // Try to fetch the value of the argument by name
            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);
        
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
        
            bindingContext.ModelState.SetModelValue(modelName,
                valueProviderResult);
        
            var value = valueProviderResult.FirstValue;
        
            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }
            // Remove unnecessary commas
            value = value.Replace(",", string.Empty);
            decimal myValue = 0;
            if (!decimal.TryParse(value, out myValue))
            {
                // Error
                bindingContext.ModelState.TryAddModelError(
                                        modelName,
                                        "Could not parse MyValue.");
                return Task.CompletedTask;
            }
            var result = new SomeClass();
            result.MyValue = myValue;
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
        
