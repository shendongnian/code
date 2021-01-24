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
                try 
                {
                    var clientsId = tokens.Select(int.Parse);
                    object model = null;
                    if (bindingContext.ModelType.IsArray)
                    {
                        model = clientsId.ToArray();
                    }
                    else if (bindingContext.ModelType == typeof(HashSet<int>))
                    {
                        model = clientsId.ToHashSet();
                    }
                    else
                    {
                        model = clientsId.ToList();
                    }                        
                    bindingContext.ModelState.SetModelValue(bindingContext.ModelName, model);
                    bindingContext.Result = ModelBindingResult.Success(model);
                    return Task.CompletedTask;
                }
                catch {
                    //...
                }
            }
            //If we reach this far something went wrong
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Cannot convert.");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
    }
