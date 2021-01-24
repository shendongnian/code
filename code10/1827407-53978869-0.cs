    public class SSASPropertyNameBinder : IModelBinder
    {
 
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
 
            var modelName = bindingContext.ModelName;
 
            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
 
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
 
            var value = valueProviderResult.FirstValue;
 
            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }
 
            ValueProviderResult newValueProviderResult = new ValueProviderResult(valueProviderResult.FirstValue.Replace(@"\", "_"));
            bindingContext.ModelState.SetModelValue(modelName, newValueProviderResult);
            SSASServerPropertyName spn;
         
            // Check if a valid SSAS property
            if (Enum.TryParse<SSASServerPropertyName>(newValueProviderResult.FirstValue, out spn))
            {
                bindingContext.Result = ModelBindingResult.Success(spn);
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"Invalid SSAS Property: {valueProviderResult.FirstValue}");
            }
 
            return Task.CompletedTask;
        }
    }
 
