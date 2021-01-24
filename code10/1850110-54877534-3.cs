    public class ScrubbingModelBinder : IModelBinder
    {
        IScrubberAttribute _attribute;
        SimpleTypeModelBinder _baseBinder;
        public ScrubbingModelBinder(Type type, IScrubberAttribute attribute)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            _attribute = attribute as IScrubberAttribute;
            _baseBinder = new SimpleTypeModelBinder(type);
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
            // Check the value sent in
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
                // Attempt to scrub the input value
                var valueAsString = valueProviderResult.FirstValue;
                var success = true;
                var result = _attribute.Scrub(valueAsString, out success);
                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }
            // If we haven't handled it, then we'll let the base SimpleTypeModelBinder handle it
            return _baseBinder.BindModelAsync(bindingContext);
        }
    }
