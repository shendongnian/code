    public class HashSetBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            var values = valueProviderResult.FirstValue.Split(',').ToHashSet(StringComparer.OrdinalIgnoreCase);
            bindingContext.Result = ModelBindingResult.Success(values);
            return Task.CompletedTask;
        }
    }
