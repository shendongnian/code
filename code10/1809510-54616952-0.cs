    public class ObjectIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);
            
            bindingContext.Result = ModelBindingResult.Success(new ObjectId(result.FirstValue));
            return Task.CompletedTask;
        }
    }
