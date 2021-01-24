    public class EnumerableBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!typeof(IEnumerable<int>).IsAssignableFrom(bindingContext.ModelType))
                throw new OpPISException("Model is not assignable from IEnumerable<int>.");
    
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
                throw new NullReferenceException();
    
            var ids = val.Values.FirstOrDefault();
            if (ids == null)
                throw new NullReferenceException();
    
            var tokens = ids.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 0)
            {
                var clientsId = tokens.Select(int.Parse);
                if (bindingContext.ModelType.IsArray)
                {
                    bindingContext.Result = ModelBindingResult.Success(clientsId.ToArray());
                }
                else if (bindingContext.ModelType == typeof(HashSet<int>))
                {
                    bindingContext.Result = ModelBindingResult.Success(clientsId.ToHashSet());
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Success(clientsId.ToList());
                }
                return Task.CompletedTask;
            }
    
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert.");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
    }
