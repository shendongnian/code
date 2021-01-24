    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
        var values = valueProviderResult.Values.Select(value => value).ToHashSet(StringComparer.OrdinalIgnoreCase);
        bindingContext.Result = ModelBindingResult.Success(values);
        return Task.CompletedTask;
    }
